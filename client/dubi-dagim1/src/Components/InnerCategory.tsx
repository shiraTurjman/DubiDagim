import { useTranslation } from "react-i18next";
import { Category } from "../types/category";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import { Item } from "../types/item";
import ItemCard from "./ItemCard";
import { Button, Dialog, DialogContent, DialogTitle, Typography } from "@mui/material";
import { CuttingShape } from "../types/cuttingShape";
import AddToCartDialog from "./AddToCartDailog";

export default function InnerCategory() {

    const { t, i18n } = useTranslation();
    const prams = useParams();
    const [category, setCategory] = useState<Category>();
    const [items, setItems] = useState<Item[]>([]);
    const [selectedItem, setSelectedItem] = useState<any>(null);
    const [cuttingShapes, setCuttingShapes] = useState<CuttingShape[]>([]);
    const [loading,setLoading] = useState(false);

    useEffect(()=>{

        axios.get(`https://localhost:44388/api/CuttingShape/GetAllCuttingShape`)
            .then(res => {
                const cuttingShapes = res.data;
                setCuttingShapes(cuttingShapes)
            });

    },[])

    useEffect(() => {
        setLoading(true);
        axios.get(`https://localhost:44388/api/Category/GetCategoryById/${prams.id}`)
            .then(res => {
                const category = res.data;
                setCategory(category)
            });

        axios.get(`https://localhost:44388/api/Item/GetItemByCategory/${prams.id}`)
            .then(res => {
                const items = res.data;
                console.log(items);
                console.log(Array.isArray(items));
                setItems([...items]);
                console.log("items"+items);
            })

    }, [prams])

    useEffect(() => {
        console.log("Updated state:", items);
        setLoading(false);
    }, [items]);

    return (
        <>
            <div
                    className="spinning-curtain"
                    style={{ display: loading ? "flex" : "none" }}
                    >
                    <div className="loader">
                    <img src="https://cdn-icons-gif.flaticon.com/9084/9084427.gif" alt="Loading..." />
                    </div>
                    </div>

            {category &&
                <>
                    
                    <div className="col-darkBlue txt-35 txt-bold flex-center mb-30 mt-30" >
                        {i18n.language === "en" ? category.categoryEnName : category.categoryHeName}
                    </div>
                    <div className="col-darkBlue txt-20 txt-bold flex-center ">
                        {category.details}
                    </div>

                    <div style={{ display: "flex", justifyContent: "center", flexWrap: "wrap" }}>

                        {items.length > 0 && items.map((item, index) => (
                            <ItemCard key={item.itemId || index} item={item}  onPress={setSelectedItem}/>
                        ))}
                        {selectedItem &&
                        <AddToCartDialog open={Boolean(selectedItem)} onClose={() => setSelectedItem(null)} item={selectedItem}/>}
                        {/* דיאלוג פרטי המוצר */}
                        {/* <Dialog open={Boolean(selectedItem)} onClose={() => setSelectedItem(null)}>
                            
                            <DialogContent>
                                {selectedItem && (
                                    <>
                                        <img src={`data:image/jpeg;base64,${selectedItem.images}`} alt={selectedItem.itemEnName} style={{ width: "100%", maxHeight: "200px" }} />
                                        <Typography variant="h6">{i18n.language ==="he" ? selectedItem.itemHeName : selectedItem.itemEnName}</Typography>
                                        <Typography variant="body1">מחיר: ₪{selectedItem.price}</Typography>
                                        <Button variant="contained" color="success" sx={{ mt: 2 }} onClick={() => alert("המוצר נוסף לעגלה!")}>
                                            {t("add_to_cart")}
                                        </Button>
                                    </>
                                )}
                            </DialogContent>
                        </Dialog> */}
                    </div>
                </>
            }
        </>
    )
}