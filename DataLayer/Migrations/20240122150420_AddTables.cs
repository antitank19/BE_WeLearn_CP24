using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Accounts_AccountId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Meetings_MeetingId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Accounts_RevieweeId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Meetings_MeetingId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewDetail_Accounts_ReviewerId",
                table: "ReviewDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewDetail_Review_ReviewId",
                table: "ReviewDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewDetail",
                table: "ReviewDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "ReviewDetail",
                newName: "ReviewDetails");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewDetail_ReviewId",
                table: "ReviewDetails",
                newName: "IX_ReviewDetails_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewDetail_ReviewerId",
                table: "ReviewDetails",
                newName: "IX_ReviewDetails_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_RevieweeId",
                table: "Reviews",
                newName: "IX_Reviews_RevieweeId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_MeetingId",
                table: "Reviews",
                newName: "IX_Reviews_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_MeetingId",
                table: "Chats",
                newName: "IX_Chats_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_AccountId",
                table: "Chats",
                newName: "IX_Chats_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewDetails",
                table: "ReviewDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Accounts_AccountId",
                table: "Chats",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Meetings_MeetingId",
                table: "Chats",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewDetails_Accounts_ReviewerId",
                table: "ReviewDetails",
                column: "ReviewerId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewDetails_Reviews_ReviewId",
                table: "ReviewDetails",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Accounts_RevieweeId",
                table: "Reviews",
                column: "RevieweeId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Meetings_MeetingId",
                table: "Reviews",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Accounts_AccountId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Meetings_MeetingId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewDetails_Accounts_ReviewerId",
                table: "ReviewDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewDetails_Reviews_ReviewId",
                table: "ReviewDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Accounts_RevieweeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Meetings_MeetingId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewDetails",
                table: "ReviewDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "ReviewDetails",
                newName: "ReviewDetail");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_RevieweeId",
                table: "Review",
                newName: "IX_Review_RevieweeId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_MeetingId",
                table: "Review",
                newName: "IX_Review_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewDetails_ReviewId",
                table: "ReviewDetail",
                newName: "IX_ReviewDetail_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewDetails_ReviewerId",
                table: "ReviewDetail",
                newName: "IX_ReviewDetail_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_MeetingId",
                table: "Chat",
                newName: "IX_Chat_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_AccountId",
                table: "Chat",
                newName: "IX_Chat_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewDetail",
                table: "ReviewDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Accounts_AccountId",
                table: "Chat",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Meetings_MeetingId",
                table: "Chat",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Accounts_RevieweeId",
                table: "Review",
                column: "RevieweeId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Meetings_MeetingId",
                table: "Review",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewDetail_Accounts_ReviewerId",
                table: "ReviewDetail",
                column: "ReviewerId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewDetail_Review_ReviewId",
                table: "ReviewDetail",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
