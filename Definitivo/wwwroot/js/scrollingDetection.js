<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>



$(document).ready(function() {
        $(window).scroll(function () {
            if ($(document).scrollTop() > 50) {
                $("p").addClass("test");
            } else {
                $("p").removeClass("test");
            }
        });
});