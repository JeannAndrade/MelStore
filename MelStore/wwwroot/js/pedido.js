
$('#NomeCliente').autocomplete({
    minLength: 2,
    delay: 500,
    source: '/api/cliente/search'
});

$('#NomeProduto').autocomplete({
    minLength: 2,
    delay: 500,
    source: '/api/produto/search'
});

$("#btnAdicionar").click(function () {
    let nomeProduto = $("#NomeProduto").val();
    let preco = $("#PrecoUnitario").val();
    let quantidade = $("#Quantidade").val();
    let rowCount = $("table tbody tr").length;
    let tableIndex = rowCount + 1;

    if (!nomeProduto) {
        $("#NomeProduto").focus();
        return;
    }

    if (!preco) {
        $("#PrecoUnitario").focus();
        return;
    }

    if (!quantidade) {
        $("#Quantidade").focus();
        return;
    }

    let markup = `<tr><th scope="row">${tableIndex}</th><td>${nomeProduto}</td><td>${preco}</td><td>${quantidade}</td></tr>`;
    $("table tbody").append(markup);

    $("#NomeProduto").val('');
    $("#PrecoUnitario").val('');
    $("#Quantidade").val('');

    let hiddenFields = `
        <input type='hidden' name='ItensPedido[${rowCount}].NomeProduto' value='${nomeProduto}'>
        <input type='hidden' name='ItensPedido[${rowCount}].PrecoUnitario' value='${preco}'>
        <input type='hidden' name='ItensPedido[${rowCount}].Quantidade' value='${quantidade}'>
       `;
    $("#hiddenFields").append(hiddenFields);
});