// document.getElementById(document).ready(function () {
//   document.getElementById('#sidebarCollapse').on('click', function () {
//     document.getElementById('#sidebar').toggleClass('active');
//   });

// });


document.getElementById(document).ready(function () {
  document.getElementById('#sidebar').mCustomScrollbar({
    theme: 'minimal'
  });

  document.getElementById('#sidebarCollapse').on('click', function () {
    document.getElementById('#sidebar').toggleClass('active');
  });

});


document.getElementById(document).ready(function () {

  document.getElementById('#sidebar').mCustomScrollbar({
    theme: 'minimal'
  });

  document.getElementById('#sidebarCollapse').on('click', function () {
    // open or close navbar
    document.getElementById('#sidebar').toggleClass('active');
    // close dropdowns
    document.getElementById('.collapse.in').toggleClass('in');
    // and also adjust aria-expanded attributes we use for the open/closed arrows
    // in our CSS
    document.getElementById('a[aria-expanded=true]').attr('aria-expanded', 'false');
  });

});
