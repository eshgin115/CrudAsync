$(document).on("click", '#PutupdateAsync', function (e) {
    e.preventDefault();
    let Aput = e.target.nextElementSibling.href;
    console.log(Aput)
    let data = { "key": "value" }
    let valuename = $(".inp-update-name").val();
    console.log(valuename)
    let valuelastname = $(".inp-update-lastname").val();
    $.ajax({
        type: 'PUT',
        url: Aput,
      
        data: {
            Name: valuename,
            LastName: valuelastname
        }
            
        , // access in body
    }).done(function () {
        console.log('SUCCESS');
    }).fail(function (msg) {
        console.log('FAIL');
    }).always(function (msg) {
        console.log('ALWAYS');
    });
    //$.ajax(
    //    {
    //        type: "PUT",
    //        url: Aput,
    //        data: {
    //            Name: valuename,
    //            LastName: valuelastname,
    //        },
    //        //statusCode: {
    //        //    200: function (data) {
    //        //        alert('1');
    //        //        AfterSavedAll();
    //        //    },
    //        //    201: function (data) {
    //        //        $("#tdbodyid").html(data);

    //        //        $(".box_modal").css({ 'overflow': 'hidden' });
    //        //        $(".box_modal").css({ 'visibility': 'collapse' });

    //        //    },
    //        //    400: function (data) {
    //        //        $(".box_modal").html(data.responseText);
    //        //    },
    //        //    404: function (data) {
    //        //        alert('3');
    //        //        bootbox.alert('<span style="color:Red;">Error While Saving Outage Entry Please Check</span>', function () { });
    //        //    }
    //        //    //}, success: function () {
    //        //    //    alert('4');
    //        //},
    //        success: function (data, textStatus) {
    //            console.log(textStatus.);

})

$(document).on("click", ".author-delete", function (event) {
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

                    $(".box_modal").css({ 'overflow': 'hidden' });
                    $(".box_modal").css({ 'visibility': 'collapse' });

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

