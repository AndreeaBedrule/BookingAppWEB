using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingAppWEB.Migrations
{
    public partial class ReservationRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReservationRoom",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRoom", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReservationRoom_Reservation_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationRoom_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserID1",
                table: "Reservation",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRoom_ReservationID",
                table: "ReservationRoom",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRoom_RoomID",
                table: "ReservationRoom",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_UserID1",
                table: "Reservation",
                column: "UserID1",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_UserID1",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "ReservationRoom");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserID1",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Reservation");
        }
    }
}
