// Denna koden körs i Webbläsaren
// Alla som går in på vår webbsida kan se denna koden

// När DOMen laddats färdigt, så vill vi köra följande JavaScript
// Vi tar nu hjälp av jQuery!
$(document).ready(function () {
    var form = $("form"); // Detta hittar formuläret som är definierat på vår sida

    // Nu vill vi lyssna på vad som händer när man trycker på "Ladda upp"
    form.submit(function (e) {

        // Detta gör så att formuläret inte skickas automatiskt!
        e.preventDefault();

        // Ladda upp bilden, alltså formuläret och filen
        // Med hjälp av AJAX!

        $.ajax({
            // Vi gör en POST, för att /Gallery/Upload är markerad med HttPost
            method: "POST",

            // Ta en titt på hur vi nu ändrat /Gallery/List
            // Som vi sett innan så returnerade Upload en Lista av bilderna efter att det laddats upp - Hur funkar detta nu?
            url: "/Gallery/Upload",

            // Datan vi ska skicka är av typen FormData, detta låter oss skicka med filen!
            // FormData vill ha ett DOM-element, därför använder vi document.getElementsByTagName, och tar sedan första formuläret vi hittar för vi har bara ett
            data: new FormData(document.getElementsByTagName("form")[0]),

            // När vårt anrop är klart, och vi får ett svar
            // Då kör vi följande funktion
            success: function (data) {

                // Titta nu i Upload.cshtml
                // Ser du att längst ner har vi <div id="result"></div>
                // Följande anrop byter ut HTML-koden som finns i denna div
                // Mot det vår PartialView renderat på server sidan, alltså får vi våra nya bilder!
                $("div#result").html(data);
            },

            // Dessa måste sättas för att vi ska kunna använda FormData!
            processData: false,
            contentType: false
        });
    });
})