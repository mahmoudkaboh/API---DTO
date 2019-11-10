namespace APIDemo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddepartment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "Student_id", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Student_id" });
            DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Students", "Department_id", c => c.Int());
            CreateIndex("dbo.Students", "Department_id");
            AddForeignKey("dbo.Students", "Department_id", "dbo.Departments", "id");
            DropTable("dbo.Courses");
            DropTable("dbo.StudentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_id, t.Course_Id });
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Students", "Department_id", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_id" });
            DropColumn("dbo.Students", "Department_id");
            DropTable("dbo.Departments");
            CreateIndex("dbo.StudentCourses", "Course_Id");
            CreateIndex("dbo.StudentCourses", "Student_id");
            AddForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "Student_id", "dbo.Students", "id", cascadeDelete: true);
        }
    }
}
