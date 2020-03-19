$(document).ready(function () {
    
    
    
});

$(function () {
    
    //AL PASAR MOUSE POR ELEMENTO "ID SECCION" 
    //llama al metodo animate pasandle el elemento y el efecto
    $('#seccion').mouseover(function () {
        
        animate('#seccion', 'zoomIn');
        
        return false;
    });

    $('#seccion2').mouseover(function () {
        animate('#seccion2', 'zoomIn');

        return false;

    });

    $('#seccion3').mouseover(function () {
        animate('#seccion3', 'zoomIn');

        //setTimeout(function () {
        //    $('img').css('visibility', 'hidden');
        //}, 2000)
        return false;
    });



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

$(function () {


})