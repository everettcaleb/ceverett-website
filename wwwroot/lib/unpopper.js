//Prevents external elements (YouTube, GitHub Gists, large images) from 'popping' in and interrupting page loading by loading them asynchronously
//Also has the side-effect of making Markdown code much more concise and simple when dealing with embedding external content
define(['jquery', 'gist-embed'], function($) {
    var youtubeRegex = /youtube\.com.*v=([^&]*)|youtu\.be\/([^\/]*$)/,
        gistRegex = /gist.github.com\/(.*$)/,
        imgRegex = /.*\.(png|gif|jpg|jpeg|svg)#unpop$/;
    
    $('article.post').find('a').each(function(i, a) {
       var $a = $(a),
           match = '';
       
       //YouTube
       var result = youtubeRegex.exec(a.href);
       if(result && (match = result[1] || result[2])) {
           $a.replaceWith('<div class="youtube-wrapper"><iframe width="700" height="700" src="https://www.youtube.com/embed/' + match + '" frameborder="0" allowfullscreen></iframe></div>');
       }
       
       //GitHub Gists
       result = gistRegex.exec(a.href);
       if(result && (match = result[1])) {
           $a.replaceWith('<div id="tempgist"></div>');
           $('#tempgist').attr('id', null).gist(match);
       }
       
       //Images
       result = imgRegex.exec(a.href);
       if(result) {
           $a.replaceWith('<img alt="' + $a.text() + '" src="' + result[0] + '"/>');
       }
    });
});