﻿using api.data;
using api.Interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment == null) { return null; }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return comment;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) { return null; }
            comment.Title = commentModel.Title;
            comment.Content = commentModel.Content;
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
