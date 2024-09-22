let cards = [];
let cancelToken;
const input = $("#search");
const select = $("#filter");
const submit = $("#submit");

$.each($("#list [data-filter]"), function(_, value){
    if(!value) return;
    
    cards.push({
        element: value,
        show: true,
        name: normalize($(value).attr("data-search")),
        typeId: $(value).attr("data-filter")
    })
})

function getSearchValue(){
    return normalize(search.val());
}

function setSearchValue(value){
    search.val(value);
}

function searchCurrentValue(){
    handleSearch(getSearchValue());
}

$("#searchForm").on("submit", function(e){
    e.preventDefault();

    handleSearch(
        $(e.target[0]).val(),
        $(e.target[1]).val()
    )
})

function normalize(value){
    return value.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase();
}

function handleSearch(search, filter){
    hideCards(cards);
    
    const list = search ? cards.filter(x => x.name.includes(normalize(search))) : cards;
    showCards(filter ? list.filter(x => x.typeId == filter) : list);
}

function showCards(list){
    list.forEach(x => {
        x.show = true;
        $(x.element).removeClass("d-none");
    });
}

function hideCards(list){
    list.forEach(x => {
        x.show = false;
        $(x.element).addClass("d-none");
    });
}