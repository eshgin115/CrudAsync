let addBtns = document.querySelectorAll('.add-product-to-basket-btn');
addBtns.forEach(x => {
    x.addEventListener('click', function (e) {
        e.preventDefault();


        fetch(e.target.href)
            .then(response => response.text())
            .then(data => {
                
                $('.cart-block').html(data);
            })
    })
});

//var removeBtns = document.querySelectorAll('.remove-product-to-basket-btn1');

$(document).on("click", '.remove-product-to-basket-btn1', function (e) {
    e.preventDefault();

    fetch(e.target.href)
        .then(response => response.text())
        .then(data => {

            $('.cart-block').html(data);


        })

})
$(document).on("click", '.modal-btn', function (e) {
    e.preventDefault();

    fetch(e.target.href)
        .then(response => response.text())
        .then(data => {

            $('.product-details-modal').html(data);


        })
    $("#quickModal").modal("show");

})


//removeBtns.forEach(x => {

//    x.onclick = function (e) {
//        e.preventDefault();

//        console.log("Hell world")


//        fetch(e.target.href)
//            .then(response => response.text())
//            .then(data => {

//                $('.cart-block').html(data);


//            })
//    }
//    x.addEventListener('click', function (e) {

//        e.preventDefault();


//        fetch(e.target.href)
//            .then(response => response.text())
//            .then(data => {

//                $('.cart-block').html(data);


//            })
//        e.stopPropagation()
//    });

//})



////AOS.init();




