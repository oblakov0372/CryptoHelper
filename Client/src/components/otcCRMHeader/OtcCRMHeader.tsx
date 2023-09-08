import { useState } from "react";
import styles from "./otcCRMHeader.module.scss";
import { Link } from "react-router-dom";

type Menu = {
  title: string;
  description: string;
  link: string;
};
const OtcCRMHeader = () => {
  const [activatedMenu, setActivatedMenu] = useState(0);
  const menus: Menu[] = [
    {
      title: "Messages",
      description: "Messages History",
      link: "/otc_crm/messages",
    },
    {
      title: "Accounting",
      description: "Telegram Users",
      link: "/otc_crm/accounting",
    },
    { title: "My Deals", description: "Leads & Deal", link: "/otc_crm/deals" },
  ];
  return (
    <div className={styles.crm_header}>
      <ul className="flex items-center">
        {menus.map((menu: Menu, index: number) => (
          <li
            key={menu.title}
            onClick={() => setActivatedMenu(index)}
            className={
              activatedMenu === index
                ? `${styles.box} ${styles.active}`
                : `${styles.box}`
            }
          >
            <Link to={menu.link} className="block">
              <span className="text-2xl uppercase font-bold">{menu.title}</span>
              <span className="block text-lg font-medium">
                {menu.description}
              </span>
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default OtcCRMHeader;
