import React, { useState } from "react";

export const Footer = () => {
  const token = JSON.parse(localStorage.getItem("token"));
  const staffText = "Logges as " + token.role + " " + token.fullname;
  const postOfficeText = "Post office " + (token.postOfficeZip === "" ? "Headquarter" : token.postOfficeZip);
  
  return (
    <footer>
      <div className="footer-user-part">
        {<p>{staffText}</p>}
      </div>
      <div className="footer-postOffice-part">
        <p>{postOfficeText}</p>
      </div>
    </footer>
  )
}

export default Footer;