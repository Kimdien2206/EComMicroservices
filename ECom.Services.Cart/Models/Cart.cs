using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Carts.Models;

public partial class Cart
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Required]
    [Column("item_id")]
    public int ItemId { get; set; }
    
    [DefaultValue(1)]
    [Column("quantity")]
    public int Quantity { get; set; }

}
