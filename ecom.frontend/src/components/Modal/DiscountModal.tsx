import { Modal } from 'antd';
import React, { useEffect, useState } from 'react'
import { ModalProps } from '../../interface/ModalProps';
import ProductCollectionDetailTable from '../Table/Product/ProductDetailTable.Collection';
import IDiscount from '../../interface/Discount';
import IProduct from '../../interface/Product';
import { fetchProductOfDiscount } from '../../api/admin/DiscountAPI';

interface CollectionModalProps extends ModalProps {
  data: IDiscount;
}

const DiscountModal = ({ isOpen, setIsModalOpen, data }: CollectionModalProps) => {

  const [products, setProducts] = useState<IProduct[]>();

  useEffect(() => {
    data && fetchProductOfDiscount(data?.id).then(({data}) => {
      console.log(data);
      setProducts(data);
    }).catch((error) => {
      console.log(error)
    })
  }, [data]);

  return (
    <Modal title={'Sản phẩm sử dụng mã giảm giá này:'} open={isOpen} width={'70vw'} footer={null} onCancel={() => setIsModalOpen((prev: boolean) => !prev)}>
      <ProductCollectionDetailTable data={products} />
    </Modal>
  )
}

export default DiscountModal