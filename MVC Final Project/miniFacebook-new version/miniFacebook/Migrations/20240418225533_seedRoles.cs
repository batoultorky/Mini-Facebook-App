using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniFacebook.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                               table: "AspNetRoles",
                               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                               values: new object[] { Guid.NewGuid().ToString(), "Member", "Member".ToUpper(), Guid.NewGuid().ToString() }
                               );
            migrationBuilder.InsertData(
              table: "AspNetRoles",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
              values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
              );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                     table: "AspNetRoles",
                     columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                     values: new object[] { Guid.NewGuid().ToString(), "Member", "Member".ToUpper(), Guid.NewGuid().ToString() }
                     );
            //migrationBuilder.InsertData(
            //  table: "AspNetRoles",
            //  columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            //  values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
            //  );

        }
    }
}
