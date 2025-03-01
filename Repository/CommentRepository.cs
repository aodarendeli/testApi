using FreeApi.Data;
using FreeApi.Interfaces;
using FreeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FreeApi.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Comment> CreateAsync(Stock stock)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();  
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var model =  await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(model == null)
            {
                return null;
            }
            _context.Comments.Remove(model);
            await _context.SaveChangesAsync();
            return model;
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
            var existing = await _context.Comments.FindAsync(id);

            if(existing == null)
            {
                return null;
            }

            existing.Title = commentModel.Title;
            existing.Content = commentModel.Content;

            await _context.SaveChangesAsync();

            return existing;
        }
    }
}