import * as React from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import { Box, FormControl, Link } from '@mui/material';

import axios from 'axios';
import { useState } from 'react';
import { Category } from '../types/category';
import { useTranslation } from 'react-i18next';
import { toast } from 'react-toastify';

interface AddCategoryProps {
  create: boolean;
  category?: Category;
  open: boolean;
  onClose: () => void;
  render?: () => void;
}

export default function AddCategory({ open, onClose, create, category,render }: AddCategoryProps) {

  const [EnName, setEnName] = useState<string>(category ? category.categoryEnName : '');
  const [HeName, setHeName] = useState<string>(category ? category.categoryHeName : '');
  const [Icon, setIcon] = useState<string>(category ? category.icon : '');
  const [Details, setDetails] = useState<string>(category ? category.details ?? '' : '');
  const [error, setError] = useState<string>('');
  // const User = useSelector((store: storeType) => store.UserReducer);
  const { t } = useTranslation();

  const saveCategory = () => {
    debugger;
    if (EnName == "" || !EnName || HeName == "" || !EnName || Icon == "" || !Icon) {
      setError('Required');
      return;
    }
    else {

      //   const categoryToAdd: Category = {
      //     categoryName: myCategoryName,
      //     userId: userId

      //   }

      const categoryToAdd: Category = {
        categoryEnName: EnName,
        categoryHeName: HeName,
        icon: Icon,
        details: Details
      }
      if (create) {
        const response = axios.post("https://localhost:44388/api/Category/AddCategory", categoryToAdd, {
          headers: {
            "Content-Type": "application/json"
          }
        }).then
          (
            function (response) {
              alert(t("add_category") + ":" + EnName + "-" + HeName);
              onClose();
              if(render)
              {render();}

            }
          ).catch(
            function (error) {
              console.log(error);
              if (error.response) {
                console.error("Response Data:", error.response.data);
                console.error("Status:", error.response.status);
                console.error("Headers:", error.response.headers);

              }

              toast.error(error.response.data || "Add Category Faild Please try again.");
            }
          );
      }
      else{
        if(!category){
          alert("category to edit not found.");
          onClose();
        }
        else {
        categoryToAdd.categoryId = category?.categoryId;

        const response = axios.put("https://localhost:44388/api/Category/UpdateCategory", categoryToAdd, {
          headers: {
            "Content-Type": "application/json"
          }
        }).then
          (
            function (response) {
              alert(t("edit_category") + ":" + EnName + "-" + HeName);
              onClose();
              if(render)
                {render();}
            }
          ).catch(
            function (error) {
              console.log(error);
              if (error.response) {
                console.error("Response Data:", error.response.data);
                console.error("Status:", error.response.status);
                console.error("Headers:", error.response.headers);

              }

              toast.error(error.response.data || "Add Category Faild Please try again.");
            });
          }
      }


    }
  };



  const checkValid = (value: any) => {
    debugger;
    if (value == '' || !value) { setError('Required'); }
    else { setError(''); }
  };

  return (
    <>
      <Dialog open={open} onClose={onClose}>
        <DialogTitle>{create ?t("add_category"): t("edit_category")}</DialogTitle>
        <DialogContent>
          <Box
            component="form"
            sx={{
              '& .MuiTextField-root': { m: 1, width: '25ch' },
            }}
            noValidate
            autoComplete="off"
          >
            <FormControl>
              <TextField
                required
                id="filled-required"
                label={t("en_name")}
                defaultValue={t("en_name")}
                variant="filled"
                value={EnName}
                onChange={(e: { target: { value: string } }) => { setEnName(e.target.value); checkValid(e.target.value); }}
                helperText={error}
              />
            </FormControl>
            <FormControl>
              <TextField
                required
                id="filled-required"
                label={t("he_name")}
                defaultValue={t("he_name")}
                variant="filled"
                value={HeName}
                onChange={(e: { target: { value: string } }) => { setHeName(e.target.value); checkValid(e.target.value); }}
                helperText={error}
              />
            </FormControl>
            <FormControl>
              <TextField
                required
                id="filled-required"
                label={t("icon")}
                defaultValue={t("icon")}
                variant="filled"
                value={Icon}
                onChange={(e: { target: { value: string } }) => { setIcon(e.target.value); checkValid(e.target.value); }}
                helperText={error}
              />
              <Link href='https://www.flaticon.com/search?word=fish' target="_blank" rel="noopener noreferrer">{t("found_icons")}</Link>
              {/* <p>הסבר להוספת אייקון - היכנס לקישור בחר אייקון מתאים לחץ מקש ימני ובחר פתח תמונה בכרטיסיה חדשה ועתק את הנתיב </p> */}
            </FormControl>

            <FormControl>
              <TextField

                label={t("details")}
                defaultValue={t("details")}
                variant="filled"
                value={Details}
                onChange={(e: { target: { value: string } }) => { setDetails(e.target.value); }}

              />
            </FormControl>
          </Box>
        </DialogContent>
        <DialogActions>
          <Button onClick={onClose}>{t("cancel")}</Button>
          <Button onClick={saveCategory}>{create ? t("add_category"): t("edit_category")}</Button>
        </DialogActions>
      </Dialog>
    </>
  );
}