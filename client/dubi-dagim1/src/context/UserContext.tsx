import { createContext, useContext, useState, useEffect } from "react";

type UserRole = "admin" | "user" | null;

interface UserContextType {
  role: UserRole;
  setRole: (role: UserRole) => void;
}

const UserContext = createContext<UserContextType | undefined>(undefined);

export const UserProvider = ({ children }: { children: React.ReactNode }) => {
  const [role, setRole] = useState<UserRole>(null);

  useEffect(() => {
    // קריאת התפקיד מה-localStorage בהעלאת האפליקציה
    const storedRole = localStorage.getItem("userRole") as UserRole;
    if (storedRole) {
      setRole(storedRole);
    }
  }, []);

  const updateRole = (newRole: UserRole) => {
    setRole(newRole);
    if (newRole) {
      localStorage.setItem("userRole", newRole);
    } else {
      localStorage.removeItem("userRole");
    }
  };

  return (
    <UserContext.Provider value={{ role, setRole: updateRole }}>
      {children}
    </UserContext.Provider>
  );
};

// פונקציה מותאמת לגישה מהירה ל-Context
export const useUser = () => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useUser must be used within a UserProvider");
  }
  return context;
};
