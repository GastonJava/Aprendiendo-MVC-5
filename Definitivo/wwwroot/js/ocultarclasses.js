/*$(window).on("load resize", function() {
  if($(window.innerWidth) < 600){
        alert("hola funciono ");
        $('.rounded-circle').hide();
  }else{
        alert("hola en else tambien funciono");
        $('.rounded-circle').show();
  }
});*/



$(document).ready(function(){
  if(window.innerWidth > 1200){
    $('.rounded-circle').addClass('no-rounded').removeClass('rounded-circle');
  }
});

$(window).resize(function(){
  if(window.innerWidth > 1200){
    $('.rounded-circle').addClass('no-rounded').removeClass('rounded-circle');
  }else{
    $('.no-rounded').addClass('rounded-circle').removeClass('no-rounded');
  }
});