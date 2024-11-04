using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;

namespace ToDoApp.DataAccess.Configurations;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.ToTable("ToDos").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ToDoId");
        builder.Property(x => x.StartDate).HasColumnName("StartTime");
        builder.Property(x => x.EndDate).HasColumnName("EndTime");
        builder.Property(x => x.CreatedDate).HasColumnName("CreateTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.Title).HasColumnName("Title");
        builder.Property(x => x.Completed).HasColumnName("IsCompleted");
        builder.Property(x => x.UserId).HasColumnName("User_Id");
        builder.Property(x => x.CategoryId).HasColumnName("Category_Id");


        builder.HasOne(x => x.User)
            .WithMany(x => x.ToDos)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.ToDos)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);



        builder.Navigation(x => x.User).AutoInclude();
        builder.Navigation(x => x.Category).AutoInclude();
        

    }
}