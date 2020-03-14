$(document).ready(function () {
    
    
    
});

$(function () {
    
    //AL PASAR MOUSE POR ELEMENTO "ID SECCION" 
    //llama al metodo animate pasandle el elemento y el efecto
    $('#seccion').mouseover(function () {
        //alert("boton funcionando");
        animate('#seccion', 'flipInX');
        //animate('#seccion2', 'slideInLeft');
        animate('#seccion2', 'zoomIn');
        return false;
    });

    //$('#animateBtn2').click(function () {
    //    animate('header', 'slideOutUp');
    //    setTimeout(function () {
    //        $('header').css('visibility', 'hidden');
    //    }, 1000);
    //    return false;
    //});

    // Animate
    function animate(element, efecto) {
        $(element).addClass('animated ' + efecto);
        $(element).addClass('animated ' + efecto);

        //al pasar 3 segundos
        var wait = setTimeout(function () {
            $(element).removeClass('animated ' + efecto);
        }, 2000);
    }
})