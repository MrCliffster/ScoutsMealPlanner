using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoutsMealPlanner.Data.Migrations
{
    public partial class FixingMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camps",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IngredientCategories",
                columns: table => new
                {
                    IngredientCategoryID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCategories", x => x.IngredientCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CampID = table.Column<Guid>(nullable: false),
                    MenuName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menus_Camps_CampID",
                        column: x => x.CampID,
                        principalTable: "Camps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IngredientCategoryID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    UnitQuantity = table.Column<double>(nullable: false),
                    UnitCost = table.Column<decimal>(type: "money", nullable: false),
                    Perishable = table.Column<bool>(nullable: false),
                    Standard = table.Column<bool>(nullable: false),
                    Vegetarian = table.Column<bool>(nullable: false),
                    GlutenFree = table.Column<bool>(nullable: false),
                    LactoseFree = table.Column<bool>(nullable: false),
                    IngredientID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingredient_IngredientCategories_IngredientCategoryID",
                        column: x => x.IngredientCategoryID,
                        principalTable: "IngredientCategories",
                        principalColumn: "IngredientCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredient_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeEquipment",
                columns: table => new
                {
                    EquipmentID = table.Column<Guid>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeEquipment", x => new { x.RecipeID, x.EquipmentID });
                    table.ForeignKey(
                        name: "FK_RecipeEquipment_Equipment_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeEquipment_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MenuID = table.Column<Guid>(nullable: false),
                    MealType = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meals_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientEntries",
                columns: table => new
                {
                    IngredientID = table.Column<Guid>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false),
                    QuantityNeeded = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientEntries", x => new { x.IngredientID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_IngredientEntries_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientEntries_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealRecipes",
                columns: table => new
                {
                    MealID = table.Column<Guid>(nullable: false),
                    RecipeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRecipes", x => new { x.MealID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_MealRecipes_Meals_MealID",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealRecipes_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Camps",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("626556f9-65ac-4da2-b099-75462405a60d"), "Stradbroke Cup" },
                    { new Guid("9fbd6d57-b590-4651-be8c-49462f76cf8c"), "Annual Camp" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("3aff04cd-288c-4cf8-a461-41a7c9e2a91f"), "Pot (Large)" });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "IngredientCategoryID", "Name" },
                values: new object[,]
                {
                    { new Guid("940da46d-e355-4a70-aea6-5650ff85eacf"), "Dairy" },
                    { new Guid("e2c53348-0f87-4fe8-af85-fa9329a9af5c"), "Pantry" },
                    { new Guid("940723ff-45eb-4977-8abb-33f3705597c4"), "Bakery" },
                    { new Guid("81a35256-2783-4d63-8f78-dcd836cb26b7"), "Meat" },
                    { new Guid("d206170b-c46e-4e27-99eb-d9b97e0a9149"), "Fresh" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("983ddaa0-bfc3-4254-9c3a-a958738cc235"), "Hot Chocolate" },
                    { new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), "Hot Dogs" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "ID", "GlutenFree", "IngredientCategoryID", "IngredientID", "LactoseFree", "Name", "Perishable", "Standard", "Unit", "UnitCost", "UnitQuantity", "Vegetarian" },
                values: new object[,]
                {
                    { new Guid("a21b0aef-f047-466b-b440-888db0762dbb"), true, new Guid("940da46d-e355-4a70-aea6-5650ff85eacf"), null, false, "Milk - Full Cream (UHT)", true, true, "Litre", 2m, 2.0, true },
                    { new Guid("93058517-d4a9-4008-9d84-0c8b2416ff35"), false, new Guid("940da46d-e355-4a70-aea6-5650ff85eacf"), null, true, "Milk - Lactose Free (UHT) (LF)", false, false, "Litre", 2m, 2.0, false },
                    { new Guid("61836688-8942-4bb6-b3f0-59ac76e16e76"), true, new Guid("e2c53348-0f87-4fe8-af85-fa9329a9af5c"), null, true, "Hot Chocolate Powder", false, true, "Kilogram", 4m, 0.40000000000000002, true },
                    { new Guid("3e106ea9-170e-42be-a956-48d618124ba6"), false, new Guid("e2c53348-0f87-4fe8-af85-fa9329a9af5c"), null, false, "Vegetarian Sausages", true, false, "Packet", 6m, 0.33000000000000002, true },
                    { new Guid("b5c71a81-a312-47fc-b65d-db676f5c817c"), true, new Guid("e2c53348-0f87-4fe8-af85-fa9329a9af5c"), null, true, "Tomato Sauce", false, true, "Bottle", 4m, 1.0, true },
                    { new Guid("5eb4eb18-9302-4c68-bfa3-5b7f620d4fdd"), true, new Guid("e2c53348-0f87-4fe8-af85-fa9329a9af5c"), null, true, "Mustard", false, true, "Bottle", 4.15m, 1.0, true },
                    { new Guid("484e1910-d39a-4c6f-8771-6246be694180"), true, new Guid("e2c53348-0f87-4fe8-af85-fa9329a9af5c"), null, true, "BBQ Sauce", false, true, "Bottle", 4m, 1.0, true },
                    { new Guid("7769dd8d-d19d-4f31-a550-131765363575"), false, new Guid("940723ff-45eb-4977-8abb-33f3705597c4"), null, true, "Hot Dog Buns", true, true, "Each", 2m, 1.0, true },
                    { new Guid("f43b47c4-d63c-441e-a9b0-18e6ed3612f4"), true, new Guid("940723ff-45eb-4977-8abb-33f3705597c4"), null, false, "Gluten Free Bread (GF)", false, false, "Loaf", 7m, 1.0, false },
                    { new Guid("40236481-6766-48e6-982b-aea9a5f751c6"), true, new Guid("81a35256-2783-4d63-8f78-dcd836cb26b7"), null, true, "Sausages", true, true, "Each", 1.16m, 1.0, false }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "ID", "CampID", "EndDate", "MenuName", "StartDate" },
                values: new object[] { new Guid("0c36e53b-5594-4913-83eb-1be922e589ae"), new Guid("626556f9-65ac-4da2-b099-75462405a60d"), new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peckers Patrol Menu", new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "RecipeEquipment",
                columns: new[] { "RecipeID", "EquipmentID" },
                values: new object[] { new Guid("983ddaa0-bfc3-4254-9c3a-a958738cc235"), new Guid("3aff04cd-288c-4cf8-a461-41a7c9e2a91f") });

            migrationBuilder.InsertData(
                table: "IngredientEntries",
                columns: new[] { "IngredientID", "RecipeID", "QuantityNeeded" },
                values: new object[,]
                {
                    { new Guid("a21b0aef-f047-466b-b440-888db0762dbb"), new Guid("983ddaa0-bfc3-4254-9c3a-a958738cc235"), 0.20000000000000001 },
                    { new Guid("93058517-d4a9-4008-9d84-0c8b2416ff35"), new Guid("983ddaa0-bfc3-4254-9c3a-a958738cc235"), 0.20000000000000001 },
                    { new Guid("61836688-8942-4bb6-b3f0-59ac76e16e76"), new Guid("983ddaa0-bfc3-4254-9c3a-a958738cc235"), 0.044999999999999998 },
                    { new Guid("3e106ea9-170e-42be-a956-48d618124ba6"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), 1.75 },
                    { new Guid("b5c71a81-a312-47fc-b65d-db676f5c817c"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), 0.02 },
                    { new Guid("5eb4eb18-9302-4c68-bfa3-5b7f620d4fdd"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), 0.01 },
                    { new Guid("484e1910-d39a-4c6f-8771-6246be694180"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), 0.01 },
                    { new Guid("7769dd8d-d19d-4f31-a550-131765363575"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), 2.0 },
                    { new Guid("f43b47c4-d63c-441e-a9b0-18e6ed3612f4"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), 0.10000000000000001 },
                    { new Guid("40236481-6766-48e6-982b-aea9a5f751c6"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506"), 1.75 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "ID", "Day", "MealType", "MenuID" },
                values: new object[,]
                {
                    { new Guid("0a8870de-543e-41d4-a495-5de07805bd3c"), 5, 4, new Guid("0c36e53b-5594-4913-83eb-1be922e589ae") },
                    { new Guid("d077dd98-0926-4e14-b788-e379a09a684b"), 6, 1, new Guid("0c36e53b-5594-4913-83eb-1be922e589ae") }
                });

            migrationBuilder.InsertData(
                table: "MealRecipes",
                columns: new[] { "MealID", "RecipeID" },
                values: new object[] { new Guid("0a8870de-543e-41d4-a495-5de07805bd3c"), new Guid("983ddaa0-bfc3-4254-9c3a-a958738cc235") });

            migrationBuilder.InsertData(
                table: "MealRecipes",
                columns: new[] { "MealID", "RecipeID" },
                values: new object[] { new Guid("d077dd98-0926-4e14-b788-e379a09a684b"), new Guid("ceaa6fa0-6d50-4b56-b566-2bdc1e10c506") });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientCategoryID",
                table: "Ingredient",
                column: "IngredientCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_IngredientID",
                table: "Ingredient",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientEntries_RecipeID",
                table: "IngredientEntries",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_MealRecipes_RecipeID",
                table: "MealRecipes",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuID",
                table: "Meals",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CampID",
                table: "Menus",
                column: "CampID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeEquipment_EquipmentID",
                table: "RecipeEquipment",
                column: "EquipmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientEntries");

            migrationBuilder.DropTable(
                name: "MealRecipes");

            migrationBuilder.DropTable(
                name: "RecipeEquipment");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "IngredientCategories");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Camps");
        }
    }
}
