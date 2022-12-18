import { DayTimeColsSlicer } from "../../../admin/assets/plugins/fullcalendar/main";


$(document).on("click", '.email-btn', function (e) {
    e.preventDefault();
    var btn = e.target;
    var input = btn.parentElement.children[0].value;
    console.log(input)

    var url = btn.parentElement.children[2].href;

    function makeRequest() {
        fetch("sdds", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Email: input,
            }),

        })
            .then(response => {
                if (response.status == 200) {
                    document.getElementById('toaster').style.opacity = '1'
                    setTimeout(() => {
                        document.getElementById('toaster').style.opacity = '0'
                    }, 1000);
                }
                if (response.status == 400) {
                    document.getElementById('toasterDan').style.opacity = '1'
                    setTimeout(() => {
                        document.getElementById('toasterDan').style.opacity = '0'
                    }, 1000);
                }
            })
            .catch(err => {
                console.log("sasd");
            });
    }

    makeRequest();

})