<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>



$(document).ready(function() {
        $(window).scroll(function () {
            if ($(document).scrollTop() > 250) {
                $("h3").addClass("test");
            } else {
                $("h3").removeClass("test");
            }
        });
});