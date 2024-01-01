import { Button, Result, Space, Spin } from 'antd';
import Title from 'antd/es/typography/Title';
import React, { useState, useEffect } from 'react'
import productData from '../../assets/fake-data/products'
import Helmet from './components/Helmet';
import ProductCard from './components/ProductCard';
import ProductView from './components/ProductView';
import IProduct from '../../interface/Product';
import { fetchProductBySlug, fetchProductDetail, increaseViewForProduct } from '../../api/CustomerAPI';
import { ScrollMenu } from 'react-horizontal-scrolling-menu';
import { LeftArrow, RightArrow } from './components/Arrow';
import { getSimilarProducts } from '../../api/recommenderAPI';
import ErrorAlert from '../../components/Alert/ErrorAlert';
import { useParams } from 'react-router-dom';
import NotFoundResult from '../../components/Result/NotFoundResult';

const Product = () => {
  const { slug } = useParams();
  const [product, setProduct] = useState<IProduct | null>(null);
  const [recProduct, setRecProduct] = useState<IProduct[]>([]);
  const [isViewedIncreasing, setIsViewedIncreasing] = useState(false)
  const [loading, setLoading] = useState(true);



  useEffect(() => {
    if (slug) {
      setLoading(true);
      fetchProductBySlug(slug).then(({ data }) => {
        console.log("🚀 ~ file: Product.tsx:28 ~ slug&&fetchProductBySlug ~ data:", data)
        setProduct(data[0]);
        if (!isViewedIncreasing)
          increaseViewForProduct(data.data[0].id).then(() => { setIsViewedIncreasing(true) });
      }).catch((err) => console.error(err)).finally(() => setLoading(false));
    }
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  }, [slug]);

  return (
    (slug && product) || loading == true ?
      (<Spin spinning={loading}>
        <Helmet title={product ? product.name : ""}>
          <Space style={{ paddingRight: '3%' }}>
            <ProductView product={product} />
          </Space>
          <Space direction='vertical' style={{ width: '100%', margin: '0 20px', paddingRight: '3%' }}>
            <Title level={2} style={{ color: 'var(--main-color)', margin: '20px 0 10px 0' }}>CÓ THỂ BẠN SẼ THÍCH</Title>
            <ScrollMenu LeftArrow={LeftArrow} RightArrow={RightArrow} Footer={null}>
              {recProduct.map((item: IProduct, index: number) => (
                <ProductCard
                  id={index}
                  key={index}
                  img01={item.image[0]}
                  img02={item.image[1]}
                  name={item.name}
                  slug={item.slug}
                  price={Number(item.price)}
                  discount={null}
                />
              ))}
            </ScrollMenu>
          </Space>
        </Helmet>
      </Spin>) : (<NotFoundResult message="Sản phẩm không tồn tại vui lòng thử lại sau." />)
  )
}

export default Product
