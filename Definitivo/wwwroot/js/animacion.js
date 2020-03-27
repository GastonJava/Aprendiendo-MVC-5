

$(function () {

    // modificar todo
    $(window).scroll(function () {

             var scrolled_val = Math.round(window.scrollY);
    
             //console.log(scrolled_val);
             //alert(scrolled_val);


        if ($(document).scrollTop() > 160 && $(document).scrollTop() < 300) {

            animate('#imagen1', 'zoomIn');
            animate('#imagen2', 'zoomIn');
            animate('#imagen3', 'zoomIn');


            return false;
        }

        if ($(document).scrollTop() > 870 && $(document).scrollTop() < 950) {
            //$("u").addClass("test");

            
            animate('#seccionn-desarrollo1', 'jackInTheBox');

            animate('#seccionn-desarrollo2', 'jackInTheBox');



            return false;
        }

        // Animate
        function animate(element, efecto) {
            $(element).addClass('animated ' + efecto);


            //al pasar 3 segundos
             var wait = setTimeout(function () {
                 $(element).removeClass('animated ' + efecto);
             }, 2000);
        }
    });
});