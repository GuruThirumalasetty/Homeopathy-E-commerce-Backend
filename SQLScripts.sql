-- Table structure for HM_Products
CREATE TABLE HM_Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    product_name VARCHAR(255) NOT NULL,
    code VARCHAR(100) NOT NULL,
    type VARCHAR(100),
    author VARCHAR(255),
    category VARCHAR(100),
    price INT NOT NULL,
    rating DECIMAL(3,2),
    image_path VARCHAR(500),
    description TEXT,
    status INT NOT NULL DEFAULT 1,
    created_on DATETIME DEFAULT CURRENT_TIMESTAMP,
    created_by VARCHAR(255),
    updated_on DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    updated_by VARCHAR(255)
);

-- Stored Procedure for Get All Products
DELIMITER //
CREATE PROCEDURE HM_PR_Get_All_Products()
BEGIN
    SELECT * FROM HM_Products;
END //
DELIMITER ;

-- Stored Procedure for Insert Product
DELIMITER //
CREATE PROCEDURE HM_PR_Insert_Product(
    IN p_ProductName VARCHAR(255),
    IN p_Code VARCHAR(100),
    IN p_Type VARCHAR(100),
    IN p_Author VARCHAR(255),
    IN p_Category VARCHAR(100),
    IN p_Price INT,
    IN p_Rating DECIMAL(3,2),
    IN p_Image_Path VARCHAR(500),
    IN p_Description TEXT,
    IN p_Status INT,
    IN p_Created_By VARCHAR(255),
    OUT p_New_Product_Id INT
)
BEGIN
    INSERT INTO HM_Products (product_name, code, type, author, category, price, rating, image_path, description, status, created_by)
    VALUES (p_ProductName, p_Code, p_Type, p_Author, p_Category, p_Price, p_Rating, p_Image_Path, p_Description, p_Status, p_Created_By);
    SET p_New_Product_Id = LAST_INSERT_ID();
END //
DELIMITER ;

-- Stored Procedure for Update Product
DELIMITER //
CREATE PROCEDURE HM_PR_Update_Product(
    IN p_Id INT,
    IN p_ProductName VARCHAR(255),
    IN p_Code VARCHAR(100),
    IN p_Type VARCHAR(100),
    IN p_Author VARCHAR(255),
    IN p_Category VARCHAR(100),
    IN p_Price INT,
    IN p_Rating DECIMAL(3,2),
    IN p_Image_Path VARCHAR(500),
    IN p_Description TEXT,
    IN p_Status INT,
    IN p_Updated_By VARCHAR(255),
    OUT p_IsUpdated INT
)
BEGIN
    UPDATE HM_Products
    SET product_name = p_ProductName,
        code = p_Code,
        type = p_Type,
        author = p_Author,
        category = p_Category,
        price = p_Price,
        rating = p_Rating,
        image_path = p_Image_Path,
        description = p_Description,
        status = p_Status,
        updated_by = p_Updated_By
    WHERE Id = p_Id;
    SET p_IsUpdated = ROW_COUNT();
END //
DELIMITER ;

-- Stored Procedure for Update Product Status
DELIMITER //
CREATE PROCEDURE HM_PR_Update_Product_Status(
    IN p_Id INT,
    IN p_Status INT,
    IN p_Updated_By VARCHAR(255),
    OUT p_IsUpdated INT
)
BEGIN
    UPDATE HM_Products
    SET status = p_Status,
        updated_by = p_Updated_By
    WHERE Id = p_Id;
    SET p_IsUpdated = ROW_COUNT();
END //
DELIMITER ;
