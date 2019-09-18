$(document).ready(function () {


    $(".bedtype").change(function () {
        $Id = $(this).val();
        $.ajax({

            url: "/ajax/SearchRoom/",
            type: "get", //Get ya Post olmasi
            data: { Id: $Id },
            success: function (res) {
                res = $($.parseHTML(res));
                $(".maintable").html(res);

            },
            error: function (error) {

                console.log(error);
            }

        });



    });


    $(document).on("click", ".activate", function () {

        $Id = $(this).data("active");
        $that = $(this);

        $.ajax({

            url: "/ajax/Active/",
            type: "get", //Get ya Post olmasi
            data: { Id: $Id },
            success: function (res) {
                //if (res.status === 200) {
                //$(".activate").parent(".parentrow").hide();

               
                //}

                $that.css("background-color", "yellow");

            },
            error: function (error) {

                console.log(error);
            }

        });

    });
})