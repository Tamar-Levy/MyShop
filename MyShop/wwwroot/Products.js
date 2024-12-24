
let urlString = `api/Products`

const drawProducts = async () => { 
    try {
        const allProducts = await fetch(urlString)
        const products = await allProducts.json()
          for (let i = 0; i < products.length; i++) {
              showOneProduct(products[i])
          }
    }
    catch (error) {
        throw error;
    }
}

const drawCategories = async () => {
    try {
        const allCategories = await fetch(`api/Categories`)
        const categories = await allCategories.json()
        for (let i = 0; i < categories.length; i++) {
            showOnecategory(categories[i])
        }
    }
    catch (error) {
        throw error;
    }
}
const productList = addEventListener("load", async () => {
    drawProducts()
    drawCategories();

    //let categoryIdArr = [];
    //sessionStorage.setItem("categoryIds", JSON.stringify(categoryIdArr))
}) 

const showOneProduct = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    if (product.image)
        cloneProduct.querySelector("img").src = `./Images/Products/${product.categoryCategoryName}/${product.image}.png`
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const showOnecategory = async (category) => {
    let tmp = document.getElementById("temp-category");
    let cloneCategory = tmp.content.cloneNode(true)
    cloneCategory.querySelector(".OptionName").textContent = category.categoryName
    cloneCategory.querySelector(".opt").addEventListener('change', () => { filterProductsByCategory(category.categoryId) })
    document.getElementById("categoryList").appendChild(cloneCategory)
}
let categoriesId = []


const getDataFromView = () => {
    const minPrice = document.querySelector("#minPrice").value
    const maxPrice = document.querySelector("#maxPrice").value
    const nameSearch = document.querySelector("#nameSearch").value
    return { minPrice, maxPrice, nameSearch };
}

const filterProductsByCategory = (id) => {
    let ind = categoriesId.indexOf(id)
    if(ind!=-1)
        categoriesId.splice(ind, 1)
    else
        categoriesId[categoriesId.length] = id
    filterProducts()
}
const filterProducts = async () => {
    const { minPrice, maxPrice, nameSearch } = getDataFromView()
            if (minPrice || maxPrice || nameSearch || categoriesId)
                urlString += '?'
            if (minPrice)
                urlString += `&minPrice=${minPrice}`
            if (maxPrice)
                urlString += `&maxPrice=${maxPrice}`
            if (nameSearch)
                urlString += `&name=${nameSearch}`
            if (categoriesId) {
                categoriesId.map(c => urlString += `&categorieIds=${c}`)
            }
        drawProducts()
    }