define(['jquery'], function($) {
    var $hamburger = $('a.hamburger'),
        $navmenu = $('ul.navmenu');
    
    $hamburger.on('click.navmenu', function(e) {
         e.preventDefault();
         
         $hamburger.toggleClass('active');
         $navmenu.toggleClass('active');
    });  
});
