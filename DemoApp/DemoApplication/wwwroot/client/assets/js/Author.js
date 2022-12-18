//$(document).on("click", '#PutupdateAsync', function (e) {
//    e.preventDefault();
//    let Aput = e.target.nextElementSibling.href;
//    console.log(Aput)
//    let valuename = $(".inp-update-name").val();
//    let valuelastname = $(".inp-update-lastname").val();
//    var insert = {};

//    insert.Name = valuename;
//    insert.LastName = valuelastname;
//    var updatedData = {
//        CrName: $(".inp-update-name").val(),
//        CrLastName: $(".inp-update-lastname").val(),
//    };

//    $.ajax({
//        type: 'PUT',
//        url: Aput,

//        processData: false,
//        dataType: 'JSON',
//        data: {
//             $(".inp-update-name").serialize(),
//        },



//    })
//})

$(document).on("click",".author-delete", function (event) {
    event.preventDefault();
    var id = $("#author-delet").attr("data-id");
    $.ajax({
        url: event.target.href,
        type: 'delete',
        data: { id: id },
        success: function (data) {

            console.log(data.status)
            $("#tdbodyid").html(data);




        },
        error: function (err) {
          alert(err)

        }
    });
})

$(document).on("click", '#btnAddAuth', function (e) {
    e.preventDefault();
    let aHref = e.target.nextElementSibling.href;
    console.log(aHref);
    $.ajax(
        {
            type: "Post",
            url: aHref,
            data: {
                Name: $(".txtFirstName").val(),
                LastName: $(".txtLastName").val()
            },
            statusCode: {
                200: function (data) {
                    alert('1');
                    AfterSavedAll();
                },
                201: function (data) {
                    $("#tdbodyid").html(data);
                    function hide2 () {
                        $(".box_modal").hide();
                    };
                    hide2();

               
                },
                400: function (data) {
                    $(".box_modal").html(data.responseText);
                },
                404: function (data) {
                    alert('3');
                    bootbox.alert('<span style="color:Red;">Error While Saving Outage Entry Please Check</span>', function () { });
                }
            //}, success: function () {
            //    alert('4');
            },
            //success: function (data, textStatus) {
            //    console.log(textStatus.);




            //    $("#tdbodyid").html(data);




            //},
            //error: function (err) {
            //    $(".box_modal").html(err.responseText);

            //}

        });

})
$(document).on("click", '.author-update', function (e) {
    e.preventDefault();
    console.log(e.target.href)
    let aHref = e.target.href;
    console.log(aHref);
    $.ajax(
        {
            url: aHref,

            success: function (data) {
                console.log(data)
                $(".product-details-modal").html(data);




            },
            error: function (err) {
                $(".product-details-modal").html(err.responseText);

            }

        });

})

