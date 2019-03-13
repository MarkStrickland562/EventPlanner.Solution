$(document).ready(function() {
  // $(this).scrollTop(0);
  $("li").click(function() {
    $("li").removeClass("active");
    $(this).addClass("active");
  });
});

// document.getElementById(document).ready(function () {

//   document.getElementById('#sidebar').mCustomScrollbar({
//     theme: 'minimal'
//   });

//   document.getElementById('#sidebarCollapse').on('click', function () {
//     // open or close navbar
//     document.getElementById('#sidebar').toggleClass('active');
//   });

// });
