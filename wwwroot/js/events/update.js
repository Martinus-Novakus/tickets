const sectorInputs = {
    name: $("#SectorInput_Name"),
    price: $("#SectorInput_Price"),
    rowCount: $("#SectorInput_RowCount"),
    seatsPerRow: $("#SectorInput_SeatsPerRow")
}

$("#SectorInput_Id").on("change", function(){
    const eventId = $(this).attr("dataeventid");
    const sectorId = $(this).val();
    
    api.get(`/manazment/podujatia/${eventId}/uprava?handler=Sector&sectorId=${sectorId}`)
    .then(resp => {
        var data = JSON.parse(resp);
        sectorInputs.name.val(data.name);
        sectorInputs.price.val(data.price);
        sectorInputs.rowCount.val(data.rowCount);
        sectorInputs.seatsPerRow.val(data.seatsPerRow);
    });
})