using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace schoolapp.api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ContactNumber2 = table.Column<int>(nullable: false),
                    ContactNumber3 = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    HomeAddress = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    OfficeAddress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DurationFrom = table.Column<DateTime>(nullable: false),
                    DurationTo = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    descrioption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    StandardId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.StandardId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedbyPersonId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ScheduledOn = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Persons_CreatedbyPersonId",
                        column: x => x.CreatedbyPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolEvents",
                columns: table => new
                {
                    SchoolEventId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedByPersonId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EventType = table.Column<int>(nullable: false),
                    ScheduledOn = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEvents", x => x.SchoolEventId);
                    table.ForeignKey(
                        name: "FK_SchoolEvents_Persons_CreatedByPersonId",
                        column: x => x.CreatedByPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    StandardId = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "StandardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTeachStdRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    StandardId = table.Column<int>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    TeacherPersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTeachStdRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTeachStdRelations_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "StandardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubTeachStdRelations_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubTeachStdRelations_Persons_TeacherPersonId",
                        column: x => x.TeacherPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectExams",
                columns: table => new
                {
                    SubjectExamId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedByPersonId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ExamId = table.Column<int>(nullable: true),
                    MaxMarks = table.Column<int>(nullable: false),
                    SceduledFrom = table.Column<DateTime>(nullable: false),
                    ScheduledTo = table.Column<DateTime>(nullable: false),
                    SubjectId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectExams", x => x.SubjectExamId);
                    table.ForeignKey(
                        name: "FK_SubjectExams_Persons_CreatedByPersonId",
                        column: x => x.CreatedByPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectExams_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventNotifications",
                columns: table => new
                {
                    EventNotificationId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IsNotified = table.Column<bool>(nullable: false),
                    ScheduledOn = table.Column<DateTime>(nullable: false),
                    SchoolEventId = table.Column<int>(nullable: true),
                    TaggedPersonPersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNotifications", x => x.EventNotificationId);
                    table.ForeignKey(
                        name: "FK_EventNotifications_SchoolEvents_SchoolEventId",
                        column: x => x.SchoolEventId,
                        principalTable: "SchoolEvents",
                        principalColumn: "SchoolEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventNotifications_Persons_TaggedPersonPersonId",
                        column: x => x.TaggedPersonPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentParentRelations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ParentPersonId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentParentRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentParentRelations_Persons_ParentPersonId",
                        column: x => x.ParentPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentParentRelations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Amount = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PlanId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    SubscribedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.SubscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendences",
                columns: table => new
                {
                    AttendenceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedByPersonId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsPresent = table.Column<bool>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    SubTeachStdRelationId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendences", x => x.AttendenceId);
                    table.ForeignKey(
                        name: "FK_Attendences_Persons_CreatedByPersonId",
                        column: x => x.CreatedByPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendences_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendences_SubTeachStdRelations_SubTeachStdRelationId",
                        column: x => x.SubTeachStdRelationId,
                        principalTable: "SubTeachStdRelations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectPeriods",
                columns: table => new
                {
                    SubjectPeriodId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedByPersonId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    SchecduledFrom = table.Column<DateTime>(nullable: false),
                    SchecduledTo = table.Column<DateTime>(nullable: false),
                    SubTeachStdRelationId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectPeriods", x => x.SubjectPeriodId);
                    table.ForeignKey(
                        name: "FK_SubjectPeriods_Persons_CreatedByPersonId",
                        column: x => x.CreatedByPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectPeriods_SubTeachStdRelations_SubTeachStdRelationId",
                        column: x => x.SubTeachStdRelationId,
                        principalTable: "SubTeachStdRelations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExams",
                columns: table => new
                {
                    StudentExamId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AttendedOn = table.Column<DateTime>(nullable: false),
                    CreatedByPersonId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsPresent = table.Column<bool>(nullable: false),
                    MarksObtained = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    SubjectExamId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExams", x => x.StudentExamId);
                    table.ForeignKey(
                        name: "FK_StudentExams_Persons_CreatedByPersonId",
                        column: x => x.CreatedByPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExams_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentExams_SubjectExams_SubjectExamId",
                        column: x => x.SubjectExamId,
                        principalTable: "SubjectExams",
                        principalColumn: "SubjectExamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationMessages",
                columns: table => new
                {
                    CommunicationMessageId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedbyPersonId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NotificationEventNotificationId = table.Column<int>(nullable: true),
                    ParentMessageCommunicationMessageId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Updatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationMessages", x => x.CommunicationMessageId);
                    table.ForeignKey(
                        name: "FK_CommunicationMessages_Persons_CreatedbyPersonId",
                        column: x => x.CreatedbyPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComMsg_EventNotifications_NotificationId",
                        column: x => x.NotificationEventNotificationId,
                        principalTable: "EventNotifications",
                        principalColumn: "EventNotificationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComMsg_EventNotifications_Parent_NotificationId",
                        column: x => x.ParentMessageCommunicationMessageId,
                        principalTable: "CommunicationMessages",
                        principalColumn: "CommunicationMessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_CreatedByPersonId",
                table: "Attendences",
                column: "CreatedByPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_StudentId",
                table: "Attendences",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_SubTeachStdRelationId",
                table: "Attendences",
                column: "SubTeachStdRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationMessages_CreatedbyPersonId",
                table: "CommunicationMessages",
                column: "CreatedbyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationMessages_NotificationEventNotificationId",
                table: "CommunicationMessages",
                column: "NotificationEventNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationMessages_ParentMessageCommunicationMessageId",
                table: "CommunicationMessages",
                column: "ParentMessageCommunicationMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventNotifications_SchoolEventId",
                table: "EventNotifications",
                column: "SchoolEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventNotifications_TaggedPersonPersonId",
                table: "EventNotifications",
                column: "TaggedPersonPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CreatedbyPersonId",
                table: "Exams",
                column: "CreatedbyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEvents_CreatedByPersonId",
                table: "SchoolEvents",
                column: "CreatedByPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExams_CreatedByPersonId",
                table: "StudentExams",
                column: "CreatedByPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExams_StudentId",
                table: "StudentExams",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExams_SubjectExamId",
                table: "StudentExams",
                column: "SubjectExamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentRelations_ParentPersonId",
                table: "StudentParentRelations",
                column: "ParentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentParentRelations_StudentId",
                table: "StudentParentRelations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StandardId",
                table: "Students",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectExams_CreatedByPersonId",
                table: "SubjectExams",
                column: "CreatedByPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectExams_ExamId",
                table: "SubjectExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectExams_SubjectId",
                table: "SubjectExams",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectPeriods_CreatedByPersonId",
                table: "SubjectPeriods",
                column: "CreatedByPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectPeriods_SubTeachStdRelationId",
                table: "SubjectPeriods",
                column: "SubTeachStdRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PlanId",
                table: "Subscriptions",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_StudentId",
                table: "Subscriptions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTeachStdRelations_StandardId",
                table: "SubTeachStdRelations",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTeachStdRelations_SubjectId",
                table: "SubTeachStdRelations",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTeachStdRelations_TeacherPersonId",
                table: "SubTeachStdRelations",
                column: "TeacherPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendences");

            migrationBuilder.DropTable(
                name: "CommunicationMessages");

            migrationBuilder.DropTable(
                name: "StudentExams");

            migrationBuilder.DropTable(
                name: "StudentParentRelations");

            migrationBuilder.DropTable(
                name: "SubjectPeriods");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "EventNotifications");

            migrationBuilder.DropTable(
                name: "SubjectExams");

            migrationBuilder.DropTable(
                name: "SubTeachStdRelations");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SchoolEvents");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
