$(function () {
    $('.sidenav').sidenav();
    $('.carousel').carousel({
        duration: 400,
        indicators: true
    });
    $('.fixed-action-btn').floatingActionButton();
    //$('.parallax').parallax();
    //$('select').formSelect();


    //Enabling and Disabling reg button
    window.EnableButton = function EnableButton(e) {
        var id = e.id;
        var value = $('#' + id).prop('checked');
        console.log(value);
        if (value) {
            $("#button").removeClass("disabled");
        } else {
            $("#button").addClass("disabled");
        }
    }


    window.onload = function () { CreateProduct() };
    //Create Product
    window.CreateProduct = function CreateProduct() {
        var name = $('#Name').val();
        var price = $('#Price').val();
        var stocks = $('#Stocks').val();
        var picture = $('.file-path').val();
        var ProductType = $('#ProductType').val();
        var Category = $('#Category').val();
        var Size = $('#Size').val();
        if(name.length > 0 && price.length > 0 && stocks.length > 0 && picture.length > 0 && ProductType.length > 0 && Category.length > 0 && Size.length > 0){
            $("#CreateProductButton").removeClass("disabled");
        }else{
            $("#CreateProductButton").addClass("disabled");
        }
    }

});
