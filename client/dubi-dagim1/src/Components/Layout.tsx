import { Outlet } from "react-router-dom";
import { useEffect, useState } from "react";
import AdminHeader from "./AdminHeader";
import UserHeader from "./UserHeader";
import { useUser } from "../context/UserContext";

export default function Layout () {
  // סימולציה של התחברות
  const { role } = useUser() || null;

  // if (!role) {
  //   return <p>Loading...</p>; // ניתן להחליף בספינר אם רוצים
  // }
  
  return (
    <div>
      {/* מציג Header לפי סוג המשתמש */}
      {/* {role === "admin" ? <AdminHeader /> : <UserHeader />} */}
      <UserHeader />
      {/* כאן נטען התוכן של הדף הנוכחי */}
      <main>
        <Outlet />
      </main>
    </div>
  );
};

