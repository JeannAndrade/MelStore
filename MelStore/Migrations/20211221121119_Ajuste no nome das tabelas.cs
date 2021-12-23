using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MelStore.Migrations
{
    public partial class Ajustenonomedastabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoId",
                table: "ItensPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Produtos_ProdutoId",
                table: "ItensPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensPedido",
                table: "ItensPedido");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "produtos");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "pedidos");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameTable(
                name: "ItensPedido",
                newName: "pedido_itens");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClienteId",
                table: "pedidos",
                newName: "IX_pedidos_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "pedido_itens",
                newName: "IX_pedido_itens_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "pedido_itens",
                newName: "IX_pedido_itens_PedidoId");

            migrationBuilder.AlterTable(
                name: "produtos",
                comment: "Tabela de produtos");

            migrationBuilder.AlterTable(
                name: "pedidos",
                comment: "Tabela de pedidos");

            migrationBuilder.AlterTable(
                name: "pedido_itens",
                comment: "Tabela de itens de pedido");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produtos",
                table: "produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidos",
                table: "pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedido_itens",
                table: "pedido_itens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_itens_pedidos_PedidoId",
                table: "pedido_itens",
                column: "PedidoId",
                principalTable: "pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_itens_produtos_ProdutoId",
                table: "pedido_itens",
                column: "ProdutoId",
                principalTable: "produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_clientes_ClienteId",
                table: "pedidos",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_itens_pedidos_PedidoId",
                table: "pedido_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_itens_produtos_ProdutoId",
                table: "pedido_itens");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_clientes_ClienteId",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produtos",
                table: "produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidos",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedido_itens",
                table: "pedido_itens");

            migrationBuilder.RenameTable(
                name: "produtos",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "pedidos",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "pedido_itens",
                newName: "ItensPedido");

            migrationBuilder.RenameIndex(
                name: "IX_pedidos_ClienteId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_itens_ProdutoId",
                table: "ItensPedido",
                newName: "IX_ItensPedido_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_pedido_itens_PedidoId",
                table: "ItensPedido",
                newName: "IX_ItensPedido_PedidoId");

            migrationBuilder.AlterTable(
                name: "Produtos",
                oldComment: "Tabela de produtos");

            migrationBuilder.AlterTable(
                name: "Pedidos",
                oldComment: "Tabela de pedidos");

            migrationBuilder.AlterTable(
                name: "ItensPedido",
                oldComment: "Tabela de itens de pedido");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensPedido",
                table: "ItensPedido",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedidos_PedidoId",
                table: "ItensPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Produtos_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
