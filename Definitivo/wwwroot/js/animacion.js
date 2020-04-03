$(function () {

    $(window).resize(function () {

        var width = $(window).width();

        if (width > 300 && width < 575) {
            //alert("extra pequeño smartphone");
        }

        if (width > 575 && width < 768) {

            //alert('igual a Smartphones');

        } 


        // aca animaciones en la tablet 

        if (width > 768 && width < 992)
        {
            //alert("igual a tablet");

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

                if ($(document).scrollTop() > 500 && $(document).scrollTop() < 700) {
                    //$("u").addClass("test");


                    //alert("aca es 500 - 700 que llegue aca al bajar de altura ");

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
        }

        if (width > 992 && width < 1200)
        {
            //alert('igual a desktop, funcionaria ANIMACION');

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
        }

        if (width > 1200)
        {
            //alert("Igual a extralarge, aca funcionaria ANIMACION");

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
        }
    });
   
});