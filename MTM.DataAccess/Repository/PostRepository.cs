﻿using MTM.DataAccess.IRepository;
using MTM.Entities.DTO;
using MTM.Entities.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MTM.CommonLibrary;

namespace MTM.DataAccess.Repository
{
    public class PostRepository : IPostRepository
    {
        #region GetUser
        public PostViewModel GetPost(string id)
        {
            PostViewModel model = new PostViewModel();
            try
            {
                using (var context = new MTMContext())
                {
                    model = (from post in context.Posts
                             join createdBy in context.Users
                             on post.CreatedUserId equals createdBy.Id
                             where
                             post.Id == id 
                             select new PostViewModel
                             {
                                 Id = post.Id,
                                 Title = post.Title,
                                 Description = post.Description,
                                 IsPublished = post.IsPublished,
                                 CreatedUserId = post.CreatedUserId,
                                 CreatedDate = post.CreatedDate,
                                 CreatedFullName = createdBy.FirstName + " " + createdBy.LastName,
                             }).First();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return model;
        }
        #endregion
        #region Update
        public ResponseModel Update(Post post)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                using (var context = new MTMContext())
                {
                    Post? isExist = context.Posts.FirstOrDefault(p => p.Id == post.Id);
                    if(isExist != null)
                    {
                        isExist.Title = post.Title;
                        isExist.Description = post.Description;
                        isExist.IsPublished = post.IsPublished;
                        isExist.UpdatedDate = post.UpdatedDate;
                        isExist.UpdatedUserId = post.UpdatedUserId;
                        context.SaveChanges();
                        response.ResponseType = Message.SUCCESS;
                        response.ResponseMessage = string.Format(Message.SAVE_SUCCESS, "Post", "updated");
                    }
                    else
                    {
                        response.ResponseType = Message.FAILURE;
                        response.ResponseMessage = string.Format(Message.NOT_EXIST, "your info");
                    }
                       
                }
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message ?? ex.Message;
                response.ResponseType = Message.FAILURE;
                response.ResponseMessage = $"An error occurred while saving the entity changes: {innerException}";
            }
            catch (Exception ex)
            {
                response.ResponseType = Message.FAILURE;
                response.ResponseMessage = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
