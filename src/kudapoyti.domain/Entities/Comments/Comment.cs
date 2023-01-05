using kudapoyti.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Domain.Entities.Comment;

public class Comment : Auditable
{
    public string Comments { get; set; } = String.Empty;

    public string User_email { get; set; } = String.Empty;

    public string User_name { get; set; } = String.Empty;

    public DateTime Date { get; set; }

    public long Place_id { get; set; }
    public virtual Places.Place Place { get; set; }
}
