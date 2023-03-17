using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission9steelea3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketLineItem_Checkouts_CheckoutId",
                table: "BasketLineItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketLineItem_CheckoutId",
                table: "BasketLineItem");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "BasketLineItem");

            migrationBuilder.AddColumn<int>(
                name: "DonationCheckoutId",
                table: "BasketLineItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_DonationCheckoutId",
                table: "BasketLineItem",
                column: "DonationCheckoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLineItem_Checkouts_DonationCheckoutId",
                table: "BasketLineItem",
                column: "DonationCheckoutId",
                principalTable: "Checkouts",
                principalColumn: "CheckoutId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketLineItem_Checkouts_DonationCheckoutId",
                table: "BasketLineItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketLineItem_DonationCheckoutId",
                table: "BasketLineItem");

            migrationBuilder.DropColumn(
                name: "DonationCheckoutId",
                table: "BasketLineItem");

            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "BasketLineItem",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_CheckoutId",
                table: "BasketLineItem",
                column: "CheckoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketLineItem_Checkouts_CheckoutId",
                table: "BasketLineItem",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "CheckoutId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
