using Microsoft.EntityFrameworkCore;

namespace backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseWithPluralizedTableNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName)) entity.SetTableName(tableName.ToPlural().ToSnakeCase());

            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().ToSnakeCase());

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName)) key.SetName(keyName.ToSnakeCase());
            }
            
            foreach (var foreignkey in entity.GetForeignKeys())
            {
                var foreignKeyConstraintName = foreignkey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyConstraintName)) 
                    foreignkey.SetConstraintName(foreignKeyConstraintName.ToSnakeCase());
            }
            
            foreach (var index in entity.GetIndexes())
            {
                var indexDatabaseName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexDatabaseName)) 
                    index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
            }
            
        }
        
    }
}