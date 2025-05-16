namespace EnrollmentSituation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseCode = c.String(nullable: false, maxLength: 20),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        CourseUnits = c.Int(nullable: false),
                        CourseLecHours = c.Int(nullable: false),
                        CourseLabHours = c.Int(nullable: false),
                        CourseTotHours = c.Int(nullable: false),
                        CourseSem = c.String(maxLength: 10),
                        CourseYrLvl = c.String(maxLength: 10),
                        ProgId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseCode)
                .ForeignKey("dbo.Programs", t => t.ProgId, cascadeDelete: true)
                .Index(t => t.ProgId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgId = c.Int(nullable: false, identity: true),
                        ProgName = c.String(nullable: false, maxLength: 100),
                        ProgYear = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ProgId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudId = c.Int(nullable: false, identity: true),
                        StudFName = c.String(nullable: false, maxLength: 50),
                        StudLName = c.String(nullable: false, maxLength: 50),
                        StudMName = c.String(maxLength: 50),
                        StudDob = c.DateTime(nullable: false),
                        StudCurrAddress = c.String(maxLength: 100),
                        StudConDstrct = c.String(maxLength: 100),
                        StudCityAddress = c.String(maxLength: 100),
                        StudContact = c.String(maxLength: 20),
                        StudEmail = c.String(maxLength: 100),
                        StudIsFirstGen = c.Boolean(nullable: false),
                        StudYrLvl = c.String(maxLength: 10),
                        StudCurrSy = c.String(maxLength: 10),
                        StudCurrSem = c.String(maxLength: 10),
                        StudStatus = c.String(maxLength: 20),
                        ProgId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudId)
                .ForeignKey("dbo.Programs", t => t.ProgId, cascadeDelete: true)
                .Index(t => t.ProgId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollId = c.Int(nullable: false, identity: true),
                        EnrollSem = c.String(nullable: false, maxLength: 10),
                        EnrollCurrSy = c.String(nullable: false, maxLength: 10),
                        EnrollTime = c.Time(nullable: false, precision: 7),
                        EnrollDay = c.String(maxLength: 15),
                        CourseCode = c.String(maxLength: 20),
                        StudId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollId)
                .ForeignKey("dbo.Courses", t => t.CourseCode)
                .ForeignKey("dbo.Students", t => t.StudId, cascadeDelete: true)
                .Index(t => t.CourseCode)
                .Index(t => t.StudId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        SchedId = c.Int(nullable: false, identity: true),
                        SchedSubjName = c.String(nullable: false, maxLength: 100),
                        SchedSem = c.String(maxLength: 10),
                        SchedCurrSy = c.String(maxLength: 10),
                        SchedSubjUnits = c.Int(nullable: false),
                        SchedHours = c.String(maxLength: 20),
                        SchedDays = c.String(maxLength: 30),
                        EnrollId = c.Int(nullable: false),
                        StudId = c.Int(nullable: false),
                        CourseCode = c.String(maxLength: 20),
                        InstrId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchedId)
                .ForeignKey("dbo.Courses", t => t.CourseCode)
                .ForeignKey("dbo.Enrollments", t => t.EnrollId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstrId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .ForeignKey("dbo.Students", t => t.StudId)
                .Index(t => t.EnrollId)
                .Index(t => t.StudId)
                .Index(t => t.CourseCode)
                .Index(t => t.InstrId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstrId = c.Int(nullable: false, identity: true),
                        InstrName = c.String(nullable: false, maxLength: 100),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InstrId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomHours = c.String(maxLength: 50),
                        RoomDays = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.TeachAssignments",
                c => new
                    {
                        InstrId = c.Int(nullable: false),
                        CourseCode = c.String(nullable: false, maxLength: 20),
                        RoomId = c.Int(nullable: false),
                        TaRoomTime = c.String(maxLength: 20),
                        TaRoomDay = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => new { t.InstrId, t.CourseCode, t.RoomId })
                .ForeignKey("dbo.Courses", t => t.CourseCode, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstrId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.InstrId)
                .Index(t => t.CourseCode)
                .Index(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "StudId", "dbo.Students");
            DropForeignKey("dbo.Schedules", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "InstrId", "dbo.Instructors");
            DropForeignKey("dbo.TeachAssignments", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.TeachAssignments", "InstrId", "dbo.Instructors");
            DropForeignKey("dbo.TeachAssignments", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Instructors", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "EnrollId", "dbo.Enrollments");
            DropForeignKey("dbo.Schedules", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Students", "ProgId", "dbo.Programs");
            DropForeignKey("dbo.Enrollments", "StudId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseCode", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ProgId", "dbo.Programs");
            DropIndex("dbo.TeachAssignments", new[] { "RoomId" });
            DropIndex("dbo.TeachAssignments", new[] { "CourseCode" });
            DropIndex("dbo.TeachAssignments", new[] { "InstrId" });
            DropIndex("dbo.Instructors", new[] { "RoomId" });
            DropIndex("dbo.Schedules", new[] { "RoomId" });
            DropIndex("dbo.Schedules", new[] { "InstrId" });
            DropIndex("dbo.Schedules", new[] { "CourseCode" });
            DropIndex("dbo.Schedules", new[] { "StudId" });
            DropIndex("dbo.Schedules", new[] { "EnrollId" });
            DropIndex("dbo.Enrollments", new[] { "StudId" });
            DropIndex("dbo.Enrollments", new[] { "CourseCode" });
            DropIndex("dbo.Students", new[] { "ProgId" });
            DropIndex("dbo.Courses", new[] { "ProgId" });
            DropTable("dbo.TeachAssignments");
            DropTable("dbo.Rooms");
            DropTable("dbo.Instructors");
            DropTable("dbo.Schedules");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Students");
            DropTable("dbo.Programs");
            DropTable("dbo.Courses");
        }
    }
}
