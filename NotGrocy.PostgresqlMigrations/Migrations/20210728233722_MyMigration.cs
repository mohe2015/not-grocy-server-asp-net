using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NotGrocy.PostgresqlMigrations.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "api_keys",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    api_key = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    expires = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    last_used = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    key_type = table.Column<string>(type: "text", nullable: false, defaultValueSql: "'default'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_keys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "batteries",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    used_in = table.Column<string>(type: "text", nullable: true),
                    charge_interval_days = table.Column<long>(type: "bigint", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active = table.Column<long>(type: "TINYINT", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_batteries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "battery_charge_cycles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    battery_id = table.Column<string>(type: "text", nullable: false),
                    tracked_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    undone = table.Column<long>(type: "TINYINT", nullable: false),
                    undone_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_battery_charge_cycles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chores",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    period_type = table.Column<string>(type: "text", nullable: false),
                    period_days = table.Column<long>(type: "bigint", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    period_config = table.Column<string>(type: "text", nullable: true),
                    track_date_only = table.Column<long>(type: "TINYINT", nullable: true, defaultValueSql: "0"),
                    rollover = table.Column<long>(type: "TINYINT", nullable: true, defaultValueSql: "0"),
                    assignment_type = table.Column<string>(type: "text", nullable: true),
                    assignment_config = table.Column<string>(type: "text", nullable: true),
                    next_execution_assigned_to_user_id = table.Column<int>(type: "INT", nullable: true),
                    consume_product_on_execution = table.Column<long>(type: "TINYINT", nullable: false),
                    product_id = table.Column<long>(type: "TINYINT", nullable: true),
                    product_amount = table.Column<double>(type: "double precision", nullable: true),
                    period_interval = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "1"),
                    active = table.Column<long>(type: "TINYINT", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chores_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chore_id = table.Column<long>(type: "bigint", nullable: false),
                    tracked_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    done_by_user_id = table.Column<long>(type: "bigint", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    undone = table.Column<long>(type: "TINYINT", nullable: false),
                    undone_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chores_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    instruction_manual_file_name = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    is_freezer = table.Column<long>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "meal_plan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    day = table.Column<DateTime>(type: "DATE", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true, defaultValueSql: "'recipe'"),
                    recipe_id = table.Column<long>(type: "bigint", nullable: true),
                    recipe_servings = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "1"),
                    note = table.Column<string>(type: "text", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    product_amount = table.Column<double>(type: "double precision", nullable: true, defaultValueSql: "0"),
                    product_qu_id = table.Column<long>(type: "bigint", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meal_plan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission_hierarchy",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission_hierarchy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_barcodes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(type: "INT", nullable: false),
                    barcode = table.Column<string>(type: "text", nullable: false),
                    qu_id = table.Column<int>(type: "INT", nullable: true),
                    amount = table.Column<double>(type: "double precision", nullable: true),
                    shopping_location_id = table.Column<long>(type: "bigint", nullable: true),
                    last_price = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_barcodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_groups",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "This is a test")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    product_group_id = table.Column<long>(type: "bigint", nullable: true),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    shopping_location_id = table.Column<long>(type: "bigint", nullable: true),
                    qu_id_purchase = table.Column<long>(type: "bigint", nullable: false),
                    qu_id_stock = table.Column<long>(type: "bigint", nullable: false),
                    qu_factor_purchase_to_stock = table.Column<double>(type: "double precision", nullable: false),
                    min_stock_amount = table.Column<long>(type: "bigint", nullable: false),
                    default_best_before_days = table.Column<long>(type: "bigint", nullable: false),
                    default_best_before_days_after_open = table.Column<long>(type: "bigint", nullable: false),
                    default_best_before_days_after_freezing = table.Column<long>(type: "bigint", nullable: false),
                    default_best_before_days_after_thawing = table.Column<long>(type: "bigint", nullable: false),
                    picture_file_name = table.Column<string>(type: "text", nullable: false),
                    tare_weight = table.Column<double>(type: "double precision", nullable: false),
                    parent_product_id = table.Column<long>(type: "bigint", nullable: false),
                    calories = table.Column<long>(type: "bigint", nullable: true),
                    due_type = table.Column<long>(type: "bigint", nullable: false),
                    quick_consume_amount = table.Column<double>(type: "double precision", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    default_print_stock_label = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quantity_unit_conversions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    from_qu_id = table.Column<int>(type: "INT", nullable: false),
                    to_qu_id = table.Column<int>(type: "INT", nullable: false),
                    factor = table.Column<double>(type: "double precision", nullable: false),
                    product_id = table.Column<int>(type: "INT", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quantity_unit_conversions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quantity_units",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    name_plural = table.Column<string>(type: "text", nullable: true),
                    plural_forms = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quantity_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    picture_file_name = table.Column<string>(type: "text", nullable: true),
                    base_servings = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "1"),
                    desired_servings = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "1"),
                    not_check_shoppinglist = table.Column<long>(type: "TINYINT", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true, defaultValueSql: "'normal'"),
                    product_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes_nestings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<long>(type: "bigint", nullable: false),
                    includes_recipe_id = table.Column<long>(type: "bigint", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    servings = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes_nestings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes_pos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    recipe_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    qu_id = table.Column<long>(type: "bigint", nullable: true),
                    only_check_single_unit_in_stock = table.Column<long>(type: "TINYINT", nullable: false),
                    ingredient_group = table.Column<string>(type: "text", nullable: true),
                    not_check_stock_fulfillment = table.Column<long>(type: "TINYINT", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    variable_amount = table.Column<string>(type: "text", nullable: true),
                    price_factor = table.Column<double>(type: "double precision", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes_pos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    session_key = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    expires = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    last_used = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shopping_list",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<decimal>(type: "numeric(15,2)", nullable: false, defaultValueSql: "0"),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    shopping_list_id = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "1"),
                    done = table.Column<int>(type: "INT", nullable: true, defaultValueSql: "0"),
                    qu_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_list", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shopping_lists",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_lists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shopping_locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    best_before_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    purchased_date = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "datetime('now', 'localtime')"),
                    stock_id = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    open = table.Column<long>(type: "TINYINT", nullable: false),
                    opened_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: true),
                    shopping_location_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stock_log",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    best_before_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    purchased_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    used_date = table.Column<DateTime>(type: "DATE", nullable: false),
                    spoiled = table.Column<long>(type: "bigint", nullable: false),
                    stock_id = table.Column<string>(type: "text", nullable: false),
                    transaction_type = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric(15,2)", nullable: false),
                    undone = table.Column<long>(type: "TINYINT", nullable: false),
                    undone_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    opened_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: true),
                    recipe_id = table.Column<long>(type: "bigint", nullable: true),
                    correlation_id = table.Column<string>(type: "text", nullable: true),
                    transaction_id = table.Column<string>(type: "text", nullable: true),
                    stock_row_id = table.Column<long>(type: "bigint", nullable: true),
                    shopping_location_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    due_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    done = table.Column<long>(type: "TINYINT", nullable: false),
                    done_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    assigned_to_user_id = table.Column<long>(type: "bigint", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_permissions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permission_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    key = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    row_updated_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "datetime('now', 'localtime')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userentities",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    caption = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    show_in_sidebar_menu = table.Column<long>(type: "TINYINT", nullable: false, defaultValueSql: "1"),
                    icon_css_class = table.Column<string>(type: "text", nullable: true),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userentities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userfield_values",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    field_id = table.Column<long>(type: "bigint", nullable: false),
                    object_id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userfield_values", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userfields",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entity = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    caption = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    show_as_column_in_tables = table.Column<long>(type: "TINYINT", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    config = table.Column<string>(type: "text", nullable: true),
                    sort_number = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userfields", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userobjects",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userentity_id = table.Column<long>(type: "bigint", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userobjects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: false),
                    row_created_timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    picture_file_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_api_keys_api_key",
                table: "api_keys",
                column: "api_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_api_keys_id",
                table: "api_keys",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_batteries_id",
                table: "batteries",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_batteries_name",
                table: "batteries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_batteries_performance1",
                table: "batteries",
                columns: new[] { "id", "active" });

            migrationBuilder.CreateIndex(
                name: "IX_battery_charge_cycles_id",
                table: "battery_charge_cycles",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chores_id",
                table: "chores",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chores_name",
                table: "chores",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_chores_performance1",
                table: "chores",
                columns: new[] { "id", "active" });

            migrationBuilder.CreateIndex(
                name: "IX_chores_log_id",
                table: "chores_log",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_equipment_id",
                table: "equipment",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_equipment_name",
                table: "equipment",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_locations_id",
                table: "locations",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_locations_name",
                table: "locations",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_meal_plan_id",
                table: "meal_plan",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permission_hierarchy_id",
                table: "permission_hierarchy",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permission_hierarchy_name",
                table: "permission_hierarchy",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_product_barcodes",
                table: "product_barcodes",
                column: "barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_barcodes_id",
                table: "product_barcodes",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_groups_id",
                table: "product_groups",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_groups_name",
                table: "product_groups",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_id",
                table: "products",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_name",
                table: "products",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_quantity_unit_conversions_id",
                table: "quantity_unit_conversions",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_quantity_units_id",
                table: "quantity_units",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_quantity_units_name",
                table: "quantity_units",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_recipes",
                table: "recipes",
                columns: new[] { "name", "type" });

            migrationBuilder.CreateIndex(
                name: "IX_recipes_id",
                table: "recipes",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipes_nestings_id",
                table: "recipes_nestings",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipes_nestings_recipe_id_includes_recipe_id",
                table: "recipes_nestings",
                columns: new[] { "recipe_id", "includes_recipe_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipes_pos_id",
                table: "recipes_pos",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sessions_id",
                table: "sessions",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sessions_session_key",
                table: "sessions",
                column: "session_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shopping_list_id",
                table: "shopping_list",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shopping_lists_id",
                table: "shopping_lists",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shopping_lists_name",
                table: "shopping_lists",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shopping_locations_id",
                table: "shopping_locations",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shopping_locations_name",
                table: "shopping_locations",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_id",
                table: "stock",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stock_performance1",
                table: "stock",
                columns: new[] { "product_id", "open", "best_before_date", "amount" });

            migrationBuilder.CreateIndex(
                name: "IX_stock_log_id",
                table: "stock_log",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_task_categories_id",
                table: "task_categories",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_task_categories_name",
                table: "task_categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_id",
                table: "tasks",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_permissions_id",
                table: "user_permissions",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_permissions_user_id_permission_id",
                table: "user_permissions",
                columns: new[] { "user_id", "permission_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_settings_id",
                table: "user_settings",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_settings_user_id_key",
                table: "user_settings",
                columns: new[] { "user_id", "key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userentities_id",
                table: "userentities",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userentities_name",
                table: "userentities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userfield_values_field_id_object_id",
                table: "userfield_values",
                columns: new[] { "field_id", "object_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userfield_values_id",
                table: "userfield_values",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userfields_entity_name",
                table: "userfields",
                columns: new[] { "entity", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userfields_id",
                table: "userfields",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userobjects_id",
                table: "userobjects",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_id",
                table: "users",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_keys");

            migrationBuilder.DropTable(
                name: "batteries");

            migrationBuilder.DropTable(
                name: "battery_charge_cycles");

            migrationBuilder.DropTable(
                name: "chores");

            migrationBuilder.DropTable(
                name: "chores_log");

            migrationBuilder.DropTable(
                name: "equipment");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "meal_plan");

            migrationBuilder.DropTable(
                name: "permission_hierarchy");

            migrationBuilder.DropTable(
                name: "product_barcodes");

            migrationBuilder.DropTable(
                name: "product_groups");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "quantity_unit_conversions");

            migrationBuilder.DropTable(
                name: "quantity_units");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "recipes_nestings");

            migrationBuilder.DropTable(
                name: "recipes_pos");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "shopping_list");

            migrationBuilder.DropTable(
                name: "shopping_lists");

            migrationBuilder.DropTable(
                name: "shopping_locations");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "stock_log");

            migrationBuilder.DropTable(
                name: "task_categories");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "user_permissions");

            migrationBuilder.DropTable(
                name: "user_settings");

            migrationBuilder.DropTable(
                name: "userentities");

            migrationBuilder.DropTable(
                name: "userfield_values");

            migrationBuilder.DropTable(
                name: "userfields");

            migrationBuilder.DropTable(
                name: "userobjects");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
