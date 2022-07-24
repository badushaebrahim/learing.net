SELECT
 dbo.inventory.*,
  dbo.medsdetails.Nameofmed,
  dbo.supplyerid.Supplyername
FROM dbo.inventory
JOIN dbo.medsdetails
  ON medsdetails.UID = medid 
JOIN dbo.supplyerid
  ON dbo.inventory.supid = dbo.supplyerid.SID where itemid =2;