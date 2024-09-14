using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace backend.Promos.Domain.Model.Aggregates;

public partial class PromoAudit:IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]public DateTimeOffset? UpdatedDate { get; set; }
}