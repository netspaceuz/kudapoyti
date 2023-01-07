using kudapoyti.DataAccess.DbConstexts;
using kudapoyti.DataAccess.Interfaces.Comments;
using kudapoyti.Domain.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.DataAccess.Repositories.Comments;

public class CommentRepository:GenericRepository<Comment>,ICommentsRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {

    }
}
