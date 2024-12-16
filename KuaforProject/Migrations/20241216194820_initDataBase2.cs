using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace b221210566_2_.Migrations
{
    /// <inheritdoc />
    public partial class initDataBase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CPassword = table.Column<string>(type: "text", nullable: false),
                    CName = table.Column<string>(type: "text", nullable: false),
                    CEmail = table.Column<string>(type: "text", nullable: false),
                    CPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerData_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralManager",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralManager_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialManager",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DirectManagerId = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialManager_GeneralManager_DirectManagerId",
                        column: x => x.DirectManagerId,
                        principalTable: "GeneralManager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialManager_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalonManager",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DirectManagerId = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalonManager_GeneralManager_DirectManagerId",
                        column: x => x.DirectManagerId,
                        principalTable: "GeneralManager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalonManager_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExample",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    DirektManagerId = table.Column<string>(type: "text", nullable: false),
                    GeneralManagerId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeExample_GeneralManager_GeneralManagerId",
                        column: x => x.GeneralManagerId,
                        principalTable: "GeneralManager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeExample_SalonManager_DirektManagerId",
                        column: x => x.DirektManagerId,
                        principalTable: "SalonManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeExample_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scudle",
                columns: table => new
                {
                    AppNo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppDate = table.Column<int>(type: "integer", nullable: false),
                    AppTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    EmployeeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    ManagerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scudle", x => x.AppNo);
                    table.ForeignKey(
                        name: "FK_Scudle_SalonManager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "SalonManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorExample",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    DirekManagerId = table.Column<string>(type: "text", nullable: false),
                    GeneralManagerId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorExample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisorExample_GeneralManager_GeneralManagerId",
                        column: x => x.GeneralManagerId,
                        principalTable: "GeneralManager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupervisorExample_SalonManager_DirekManagerId",
                        column: x => x.DirekManagerId,
                        principalTable: "SalonManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupervisorExample_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppNo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppDate = table.Column<int>(type: "integer", nullable: false),
                    AppTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    EmployeeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    Coast = table.Column<float>(type: "real", nullable: false),
                    SupervisorId = table.Column<string>(type: "text", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppNo);
                    table.ForeignKey(
                        name: "FK_Appointments_SupervisorExample_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "SupervisorExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HCareSv",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCareSv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCareSv_SupervisorExample_Id",
                        column: x => x.Id,
                        principalTable: "SupervisorExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HCutSv",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCutSv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCutSv_SupervisorExample_Id",
                        column: x => x.Id,
                        principalTable: "SupervisorExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HDyeSv",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDyeSv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDyeSv_SupervisorExample_Id",
                        column: x => x.Id,
                        principalTable: "SupervisorExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManikurS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManikurS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManikurS_SupervisorExample_Id",
                        column: x => x.Id,
                        principalTable: "SupervisorExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PadikurS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadikurS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PadikurS_SupervisorExample_Id",
                        column: x => x.Id,
                        principalTable: "SupervisorExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HCare",
                columns: table => new
                {
                    SupervisorId = table.Column<string>(type: "text", nullable: false),
                    DepName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_HCare_HCareSv_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "HCareSv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HCareEmp",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HCareSvId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCareEmp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCareEmp_EmployeeExample_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HCareEmp_HCareSv_HCareSvId",
                        column: x => x.HCareSvId,
                        principalTable: "HCareSv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HCut",
                columns: table => new
                {
                    SupervisorId = table.Column<string>(type: "text", nullable: false),
                    DepName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_HCut_HCutSv_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "HCutSv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HCutEmp",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HCareSvId = table.Column<string>(type: "text", nullable: false),
                    HCutSvId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCutEmp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCutEmp_EmployeeExample_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HCutEmp_HCareSv_HCareSvId",
                        column: x => x.HCareSvId,
                        principalTable: "HCareSv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HCutEmp_HCutSv_HCutSvId",
                        column: x => x.HCutSvId,
                        principalTable: "HCutSv",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HDye",
                columns: table => new
                {
                    supervisorId = table.Column<string>(type: "text", nullable: false),
                    DepName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_HDye_HDyeSv_supervisorId",
                        column: x => x.supervisorId,
                        principalTable: "HDyeSv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HDyeEmp",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HDyeSvId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDyeEmp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDyeEmp_EmployeeExample_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HDyeEmp_HDyeSv_HDyeSvId",
                        column: x => x.HDyeSvId,
                        principalTable: "HDyeSv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manikur",
                columns: table => new
                {
                    SupervisorId = table.Column<string>(type: "text", nullable: false),
                    DepName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Manikur_ManikurS_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "ManikurS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManikurE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ManikurSId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManikurE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManikurE_EmployeeExample_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManikurE_ManikurS_ManikurSId",
                        column: x => x.ManikurSId,
                        principalTable: "ManikurS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PadikurE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PadikurSId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadikurE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PadikurE_EmployeeExample_Id",
                        column: x => x.Id,
                        principalTable: "EmployeeExample",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PadikurE_PadikurS_PadikurSId",
                        column: x => x.PadikurSId,
                        principalTable: "PadikurS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedikur",
                columns: table => new
                {
                    SupervisorId = table.Column<string>(type: "text", nullable: false),
                    DepName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Pedikur_PadikurS_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "PadikurS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SupervisorId",
                table: "Appointments",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExample_DirektManagerId",
                table: "EmployeeExample",
                column: "DirektManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExample_GeneralManagerId",
                table: "EmployeeExample",
                column: "GeneralManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialManager_DirectManagerId",
                table: "FinancialManager",
                column: "DirectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_HCare_SupervisorId",
                table: "HCare",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_HCareEmp_HCareSvId",
                table: "HCareEmp",
                column: "HCareSvId");

            migrationBuilder.CreateIndex(
                name: "IX_HCut_SupervisorId",
                table: "HCut",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_HCutEmp_HCareSvId",
                table: "HCutEmp",
                column: "HCareSvId");

            migrationBuilder.CreateIndex(
                name: "IX_HCutEmp_HCutSvId",
                table: "HCutEmp",
                column: "HCutSvId");

            migrationBuilder.CreateIndex(
                name: "IX_HDye_supervisorId",
                table: "HDye",
                column: "supervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_HDyeEmp_HDyeSvId",
                table: "HDyeEmp",
                column: "HDyeSvId");

            migrationBuilder.CreateIndex(
                name: "IX_Manikur_SupervisorId",
                table: "Manikur",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ManikurE_ManikurSId",
                table: "ManikurE",
                column: "ManikurSId");

            migrationBuilder.CreateIndex(
                name: "IX_PadikurE_PadikurSId",
                table: "PadikurE",
                column: "PadikurSId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedikur_SupervisorId",
                table: "Pedikur",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_SalonManager_DirectManagerId",
                table: "SalonManager",
                column: "DirectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Scudle_ManagerId",
                table: "Scudle",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorExample_DirekManagerId",
                table: "SupervisorExample",
                column: "DirekManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorExample_GeneralManagerId",
                table: "SupervisorExample",
                column: "GeneralManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "CustomerData");

            migrationBuilder.DropTable(
                name: "FinancialManager");

            migrationBuilder.DropTable(
                name: "HCare");

            migrationBuilder.DropTable(
                name: "HCareEmp");

            migrationBuilder.DropTable(
                name: "HCut");

            migrationBuilder.DropTable(
                name: "HCutEmp");

            migrationBuilder.DropTable(
                name: "HDye");

            migrationBuilder.DropTable(
                name: "HDyeEmp");

            migrationBuilder.DropTable(
                name: "Manikur");

            migrationBuilder.DropTable(
                name: "ManikurE");

            migrationBuilder.DropTable(
                name: "PadikurE");

            migrationBuilder.DropTable(
                name: "Pedikur");

            migrationBuilder.DropTable(
                name: "Scudle");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "HCareSv");

            migrationBuilder.DropTable(
                name: "HCutSv");

            migrationBuilder.DropTable(
                name: "HDyeSv");

            migrationBuilder.DropTable(
                name: "ManikurS");

            migrationBuilder.DropTable(
                name: "EmployeeExample");

            migrationBuilder.DropTable(
                name: "PadikurS");

            migrationBuilder.DropTable(
                name: "SupervisorExample");

            migrationBuilder.DropTable(
                name: "SalonManager");

            migrationBuilder.DropTable(
                name: "GeneralManager");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
