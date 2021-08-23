using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class seed_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Ida Gibson" },
                    { 2, "Lula Nitzsche" },
                    { 3, "Dana Daniel" },
                    { 4, "Lora Ernser" },
                    { 5, "Vergie Gerhold" },
                    { 6, "Daphney Waters" },
                    { 7, "Bertram Bergnaum" },
                    { 8, "Rubye Gusikowski" },
                    { 9, "Mike Green" },
                    { 10, "Rachelle Hayes" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 9, "Modesta Terry", 1 },
                    { 8, "Neha Kreiger", 0 },
                    { 7, "Cesar Tremblay", 1 },
                    { 6, "Vicenta Bogan", 0 },
                    { 10, "Eddie McGlynn", 0 },
                    { 4, "Jameson Williamson", 0 },
                    { 3, "Ursula Boyle", 1 },
                    { 2, "Greyson Walker", 0 },
                    { 1, "Tillman Zemlak", 1 },
                    { 5, "Cyrus Berge", 1 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "Birthdate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 8, 5, 21, 44, 6, 681, DateTimeKind.Local).AddTicks(9525), "Elyse Cassin", 1, new DateTime(2021, 8, 6, 18, 20, 53, 146, DateTimeKind.Local).AddTicks(5166), new DateTime(2021, 8, 5, 23, 28, 15, 933, DateTimeKind.Local).AddTicks(1538) },
                    { 9, new DateTime(2021, 8, 5, 22, 12, 57, 676, DateTimeKind.Local).AddTicks(9865), "Ronaldo Bayer", 5, new DateTime(2021, 8, 6, 17, 17, 38, 643, DateTimeKind.Local).AddTicks(8583), new DateTime(2021, 8, 6, 6, 34, 6, 370, DateTimeKind.Local).AddTicks(7573) },
                    { 7, new DateTime(2021, 8, 6, 5, 25, 54, 145, DateTimeKind.Local).AddTicks(661), "Easter Homenick", 4, new DateTime(2021, 8, 6, 14, 47, 43, 648, DateTimeKind.Local).AddTicks(178), new DateTime(2021, 8, 5, 21, 4, 59, 401, DateTimeKind.Local).AddTicks(2522) },
                    { 6, new DateTime(2021, 8, 6, 19, 12, 6, 617, DateTimeKind.Local).AddTicks(3811), "Curtis Little", 3, new DateTime(2021, 8, 5, 20, 54, 50, 292, DateTimeKind.Local).AddTicks(6629), new DateTime(2021, 8, 6, 0, 42, 32, 538, DateTimeKind.Local).AddTicks(1788) },
                    { 8, new DateTime(2021, 8, 6, 2, 58, 52, 452, DateTimeKind.Local).AddTicks(4600), "Darron Barton", 11, new DateTime(2021, 8, 6, 14, 55, 40, 568, DateTimeKind.Local).AddTicks(5083), new DateTime(2021, 8, 5, 22, 2, 20, 20, DateTimeKind.Local).AddTicks(6155) },
                    { 4, new DateTime(2021, 8, 6, 16, 56, 49, 527, DateTimeKind.Local).AddTicks(1792), "Osbaldo Homenick", 7, new DateTime(2021, 8, 6, 14, 33, 55, 701, DateTimeKind.Local).AddTicks(5825), new DateTime(2021, 8, 6, 18, 57, 15, 33, DateTimeKind.Local).AddTicks(7174) },
                    { 3, new DateTime(2021, 8, 6, 2, 35, 32, 211, DateTimeKind.Local).AddTicks(9173), "Audie Mosciski", 9, new DateTime(2021, 8, 6, 18, 34, 23, 694, DateTimeKind.Local).AddTicks(575), new DateTime(2021, 8, 6, 17, 50, 50, 555, DateTimeKind.Local).AddTicks(6256) },
                    { 2, new DateTime(2021, 8, 5, 22, 30, 42, 231, DateTimeKind.Local).AddTicks(2321), "Ralph Weimann", 18, new DateTime(2021, 8, 6, 13, 6, 32, 605, DateTimeKind.Local).AddTicks(5274), new DateTime(2021, 8, 5, 23, 25, 2, 32, DateTimeKind.Local).AddTicks(2241) },
                    { 1, new DateTime(2021, 8, 6, 8, 51, 47, 75, DateTimeKind.Local).AddTicks(8532), "Michael Fadel", 2, new DateTime(2021, 8, 6, 16, 19, 34, 568, DateTimeKind.Local).AddTicks(5415), new DateTime(2021, 8, 6, 15, 47, 34, 867, DateTimeKind.Local).AddTicks(8176) },
                    { 5, new DateTime(2021, 8, 6, 7, 0, 11, 90, DateTimeKind.Local).AddTicks(3591), "Darien Murazik", 12, new DateTime(2021, 8, 6, 11, 49, 44, 733, DateTimeKind.Local).AddTicks(1670), new DateTime(2021, 8, 6, 1, 31, 27, 695, DateTimeKind.Local).AddTicks(2999) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 9, "Odio aut velit similique itaque. Molestias placeat vitae aut in sed nemo dicta. Exercitationem sit tempora velit quaerat at debitis officiis temporibus ut. Debitis sunt qui facere aut. Amet eaque eum qui. Vel atque dolor quos quasi sed non amet rem.", "Margarett Mueller" },
                    { 1, "Et eligendi aspernatur quis. Repellat molestias vitae occaecati aut sunt. Officia autem repellat fugiat magni at autem dolores vero qui.", "Brain Stanton" },
                    { 2, "Quaerat est sapiente soluta ratione aspernatur nesciunt dolorem placeat at. Rerum iusto nulla sed aut illum sint ipsa. Quisquam sit iste occaecati illum ut et.", "Kobe Heller" },
                    { 3, "Dolore ipsa non quod eveniet quia voluptas. Doloribus quo voluptas quae ratione sed sit quam provident. Placeat consequatur quia aut distinctio dolore molestiae illo odio eos.", "Taya Miller" },
                    { 4, "Nam quis eum ut voluptates aut. Doloribus aut illo illo maxime a quis voluptate. Harum vel ut et id. Ea dignissimos vel. Vel nulla soluta reiciendis rerum.", "Gilda Gaylord" },
                    { 5, "Eos qui veniam excepturi molestiae quia. Doloremque sequi facere repudiandae quis rerum facilis quia incidunt. Harum delectus officiis. Molestiae earum cupiditate et nostrum autem enim.", "Zena Brekke" },
                    { 6, "Libero et unde et aliquid corporis. Nostrum nulla quae quia est laudantium asperiores. Velit natus placeat nulla. Nostrum esse temporibus recusandae aut omnis aut eos provident. Aperiam ipsa dicta nihil dolorum minus.", "Ayana Mraz" },
                    { 7, "Sunt tempore accusantium ut quisquam magnam inventore quidem fugit. Placeat dolore voluptatem et sed magnam sed. Dolorum deserunt quam ea omnis in perferendis. Animi ipsa quis odio. Itaque officiis ab. Et reprehenderit magnam non et cumque dolore voluptatem.", "Tre Powlowski" },
                    { 8, "Dolor modi consequatur et atque alias quis autem est. Fuga cupiditate natus est sit voluptatem cum dolores vel autem. Et qui vero et. Doloribus necessitatibus ipsum vel dolorem nihil. Vel nihil illum alias. Et itaque qui tempore reiciendis nihil voluptas est est.", "William Pfannerstill" },
                    { 10, "Totam possimus atque est quos natus. Dolorum doloremque cum. Quam est voluptas alias adipisci sit enim cumque aspernatur. Quis quod sit voluptas dolor nisi. Id quasi deserunt aliquam dolore quo veniam aliquam porro praesentium. Dolorem vel adipisci repellendus consequatur quam architecto.", "Jalen DuBuque" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 6, 8, 2, new DateTime(2021, 8, 6, 19, 16, 13, 256, DateTimeKind.Local).AddTicks(8223), 2, "Sed velit ipsa officia et consequatur dolorem sit.", "Est vel quia qui voluptatem. Quis facere quidem laudantium excepturi ut molestias. Atque ab id. Dolorem ducimus in sint corrupti. Est consectetur voluptatibus. Et autem saepe qui est commodi in reprehenderit quia.\n\nAsperiores id placeat ea nemo et aliquid sequi. Consequatur temporibus minima molestias quo ducimus recusandae quia necessitatibus quis. Architecto est est rerum voluptatem similique. Laudantium ratione quisquam sunt officiis maiores rerum quia. Est nesciunt sit ipsum exercitationem aperiam sit tenetur beatae.\n\nMaiores voluptas et consectetur quas necessitatibus. Et eum asperiores. Explicabo id quia necessitatibus aut et porro repudiandae exercitationem.", 8, "Vel officia nam vitae nostrum voluptas aut quo consequatur." },
                    { 10, 4, 3, new DateTime(2021, 8, 5, 21, 2, 42, 163, DateTimeKind.Local).AddTicks(2040), 7, "Quo similique culpa.", "Similique sit sunt et pariatur rerum dolores neque aut. Tenetur dolor ad. Voluptatibus ullam omnis. Ut officia aperiam et sint libero repudiandae doloribus. Delectus fugit qui velit nostrum consectetur debitis. Nostrum sit animi.\n\nMagnam quia provident fugiat est. Et doloremque quasi quia. A et vel minus tenetur nam et. Vero inventore dolorem quae corrupti repudiandae distinctio maiores in illo. Fugit quia optio rerum suscipit voluptates vitae nobis. Soluta corrupti omnis eveniet itaque et labore quos vel ratione.\n\nMinima est fugit enim vitae architecto quae. Aut et aut aut vel inventore quam voluptatem nesciunt ipsa. Accusamus voluptatibus aut enim consequatur quas enim aut est.", 7, "Voluptate omnis fugit illo rem quis fuga assumenda." },
                    { 3, 7, 4, new DateTime(2021, 8, 6, 14, 51, 54, 376, DateTimeKind.Local).AddTicks(2839), 3, "Officiis ut ut adipisci sint.", "Nisi dolor et non consequatur libero natus et eveniet libero. Labore aperiam odio ullam et necessitatibus vitae architecto enim. Sit atque officia occaecati omnis dicta illo non. Iste laboriosam voluptates sit nobis ut excepturi perferendis. Incidunt harum soluta aut dolorum odit. Sed ut molestiae omnis aliquid.\n\nOfficia incidunt nesciunt eligendi doloremque. Dolore qui molestias quis consectetur fugit. Voluptas cumque possimus hic ex officiis.\n\nRerum veritatis quia et deleniti incidunt facilis id consequuntur. Ea corrupti inventore quia aspernatur cupiditate. Deleniti id voluptatem est quia qui illum molestias. Sapiente esse deserunt reiciendis voluptate deleniti vel odio. Ipsum maiores dolorem unde dolor animi nulla vel quo fugiat.", 2, "Et labore voluptatem ea." },
                    { 7, 4, 6, new DateTime(2021, 8, 6, 9, 45, 36, 313, DateTimeKind.Local).AddTicks(5850), 1, "Repellat minus assumenda cupiditate aut.", "Repellat ea voluptatem est ut neque. Cupiditate quia est ratione qui autem est et sunt. Laboriosam illo molestiae iste totam facere exercitationem porro magni.\n\nQuo officiis facere et maiores voluptatem. Quibusdam sit illum. Facilis consequatur distinctio eum velit similique. Autem numquam earum blanditiis asperiores molestias. Dolores necessitatibus non est est inventore odit labore. Nobis ducimus ut est sequi.\n\nConsequuntur omnis reiciendis et voluptate natus saepe vitae. Qui voluptas suscipit quo corrupti. Debitis dolore voluptas at autem deserunt. Exercitationem possimus ipsam voluptate. Aut recusandae dignissimos et ut voluptatem error illum ut sit.", 20, "Non officia maiores et accusantium temporibus pariatur repellendus." },
                    { 4, 1, 7, new DateTime(2021, 8, 6, 17, 34, 11, 114, DateTimeKind.Local).AddTicks(8555), 7, "Et exercitationem nihil cupiditate quis.", "Aut et autem molestiae sed eum non molestiae unde aut. Natus maiores aut enim tenetur consequatur ea soluta. Non quo et et quas et totam.\n\nAutem cumque incidunt autem tenetur excepturi assumenda harum soluta optio. Earum voluptas asperiores reprehenderit est odit. Voluptatum perspiciatis ipsam quam repellendus. Excepturi nam enim autem rerum nihil. Commodi velit occaecati quia aut sint voluptas aperiam quis quas.\n\nNam numquam officia quis. Pariatur expedita qui quaerat doloribus amet deserunt a repudiandae. Veniam quis et qui est quaerat repellendus aut quod. Qui quis quaerat nisi suscipit.", 5, "Illum enim tempora ratione voluptatem." },
                    { 2, 2, 8, new DateTime(2021, 8, 6, 15, 47, 57, 518, DateTimeKind.Local).AddTicks(1174), 12, "Voluptates quis saepe non.", "Iure hic natus voluptatem libero. Quibusdam officiis quisquam excepturi. Perspiciatis non ullam. Facere aut esse quas.\n\nOdio at qui in consequuntur voluptas praesentium voluptatem nisi. Aspernatur quia laudantium. Modi et voluptatem odio aperiam occaecati. Nam autem sed corrupti magnam quae dolorum quasi quidem.\n\nUt iusto hic explicabo reiciendis. Ut voluptas laboriosam pariatur autem atque aut laboriosam laudantium qui. Eum corrupti aut totam molestiae sunt est deleniti quae voluptates. Minima voluptas hic impedit optio assumenda nemo accusantium cupiditate.", 5, "Aperiam sit nisi fugiat qui dignissimos placeat eum." },
                    { 1, 4, 9, new DateTime(2021, 8, 6, 7, 9, 52, 331, DateTimeKind.Local).AddTicks(8505), 2, "Et quia deleniti rerum odit sed voluptatem et.", "Voluptas amet labore magnam et quo. Placeat quia dolorem quisquam repudiandae ut similique. Dolor sint eveniet cum. Laudantium nam excepturi.\n\nUt reprehenderit vitae ipsa velit nisi eveniet ipsum cum. Vero molestias modi illo. Enim sed aut voluptas numquam est temporibus facere aut voluptas.\n\nExcepturi quis aperiam aspernatur cum neque iure incidunt. Cupiditate nihil voluptas deleniti dolorem quod. Iusto nemo tempore exercitationem.", 1, "Eligendi voluptatem eos sit est et amet." },
                    { 8, 6, 9, new DateTime(2021, 8, 6, 12, 25, 20, 608, DateTimeKind.Local).AddTicks(4658), 5, "Est repudiandae odit omnis.", "Et ratione eveniet consequatur explicabo quasi voluptatem. Atque eos distinctio dignissimos ad vel ratione quo. Accusantium perspiciatis rerum fugit tempore. Est eaque non aut quas. Rerum autem reiciendis quia perferendis architecto ullam velit consectetur. Cumque autem non illum quo inventore odio accusantium.\n\nQui sapiente velit et fugit dignissimos dolore repellendus ipsum assumenda. Sapiente facilis fugiat voluptas. Nobis sed quaerat. Pariatur nihil odit iure voluptas. Ut vero est nam animi et suscipit. Eligendi cum mollitia repudiandae non sunt dolorem.\n\nQuam voluptatum id qui. Aut facilis autem quia voluptas totam. Quisquam vero consequatur. Id ut reprehenderit dolores. Ipsum quaerat et inventore qui dolorem rem.", 4, "Aut corporis sequi inventore voluptatibus quaerat modi est." },
                    { 5, 6, 10, new DateTime(2021, 8, 6, 2, 51, 49, 35, DateTimeKind.Local).AddTicks(7976), 19, "Libero optio quia est et omnis tenetur qui aut.", "Magni odit quidem officiis debitis aut pariatur illo. Natus in illo. Aut qui animi libero autem molestias ea asperiores illum accusamus. Incidunt eos qui qui qui id.\n\nVero qui reiciendis itaque ea velit et. Architecto et qui delectus. Ut quisquam quos officiis voluptas unde qui dolore quia possimus.\n\nUt rerum quod eum. Expedita nihil praesentium. Velit nisi ut quia et aliquam omnis commodi quis placeat. Et excepturi voluptatem esse labore at.", 1, "Perferendis molestiae numquam amet facere." },
                    { 9, 5, 10, new DateTime(2021, 8, 6, 6, 2, 38, 830, DateTimeKind.Local).AddTicks(1547), 9, "Possimus quas qui ut eum quis.", "Ut qui repellendus eligendi id doloremque iusto. Minus dolore numquam aut tempore ut. Quia id esse beatae maiores minus ut ipsum eveniet. Eum sit molestias. Modi saepe quia omnis. Ipsum ut nobis beatae corporis distinctio quae.\n\nOdio optio asperiores odit quis architecto. Soluta eos veritatis debitis temporibus molestiae est rerum in. Aut molestiae dolore excepturi ex explicabo ut eos veritatis. Quos cupiditate fugit esse earum est. Qui sed quia. Qui iusto corporis ut aperiam veritatis aut maxime.\n\nQuibusdam quas non et sed quo itaque dicta. Est delectus modi laborum suscipit sequi placeat. Itaque sit suscipit et nobis qui illo minima. Earum ut voluptatem aperiam laudantium qui. Voluptas eligendi voluptatem officia voluptas.", 8, "Quis ad eos." }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanion",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 4, 6, 6 },
                    { 5, 4, 9 },
                    { 1, 1, 9 },
                    { 3, 4, 5 },
                    { 10, 2, 8 },
                    { 7, 4, 8 },
                    { 2, 8, 8 },
                    { 9, 3, 3 },
                    { 8, 7, 3 },
                    { 6, 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemy",
                columns: new[] { "EpisodeEnemyId", "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 2, 3, 4 },
                    { 5, 5, 4 },
                    { 6, 7, 9 },
                    { 7, 8, 8 },
                    { 8, 9, 10 },
                    { 3, 1, 10 },
                    { 1, 10, 9 },
                    { 4, 3, 9 },
                    { 9, 3, 3 },
                    { 10, 2, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 10);
        }
    }
}
