$("#sectors").on("change", function(){
    const eventId = $(this).attr("dataeventid");
    const sectorId = $(this).val();
    
    api.get(`/podujatia/${eventId}/vstupenky?handler=Sector&sectorId=${sectorId}`)
    .then(resp => {
        $("#sector-container").html(resp)
        attachListeners();
    });
})

function attachListeners(){
    $("[data-id]").on("click", function(){
        const checkbox = $(this).prev();
        console.log(checkbox.prop("checked"))

        if($(this).hasClass("reserved")) return;
        
        
        if(checkbox.prop("checked")){
            checkbox.prop("checked", false);
            $(this).removeClass("selected");
        }else{
            checkbox.prop("checked", true);
            $(this).addClass("selected");
        }
    })
}

attachListeners();