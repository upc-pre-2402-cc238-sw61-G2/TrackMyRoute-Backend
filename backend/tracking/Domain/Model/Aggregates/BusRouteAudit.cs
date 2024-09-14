using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace backend.tracking;

public partial class BusRoute : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate {get; set;}
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set;}
    
}