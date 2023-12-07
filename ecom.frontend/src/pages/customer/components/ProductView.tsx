import { Button, Carousel, Col, Image, InputNumber, Radio, RadioChangeEvent, Row, Space, Spin, Tag, Typography } from 'antd'
import { useState, useEffect } from 'react'
import { createCart, fetchProduct, increaseViewForProduct } from '../../../api/CustomerAPI'
import ImageGallery from 'react-image-gallery';
import 'react-image-gallery/styles/scss/image-gallery.scss'
import ReactImageGallery from 'react-image-gallery';
import { ReactImageGalleryItem } from 'react-image-gallery';
import IProduct from '../../../interface/Product';
import { useNavigate } from 'react-router-dom';
import LocalStorage from '../../../helper/localStorage';
import ErrorAlert from '../../../components/Alert/ErrorAlert';
import { formatNumberWithComma } from '../../../helper/utils';
import ICart from '../../../interface/Cart';
import SuccessAlert from '../../../components/Alert/SuccessAlert';

const images = [
    {
        original: 'https://picsum.photos/id/1018/1000/600/',
        thumbnail: 'https://picsum.photos/id/1018/250/150/',
    },
    {
        original: 'https://picsum.photos/id/1015/1000/600/',
        thumbnail: 'https://picsum.photos/id/1015/250/150/',
    },
    {
        original: 'https://picsum.photos/id/1019/1000/600/',
        thumbnail: 'https://picsum.photos/id/1019/250/150/',
    },
];

const ProductView = (props: ProductViewProps) => {
    const [product, setProduct] = useState<IProduct>();

    const [previewImg, setPreviewImg] = useState<ReactImageGalleryItem[]>();

    const [color, setColor] = useState<object[]>();

    const [size, setSize] = useState<object[]>();

    const [quantity, setQuantity] = useState(1);

    const [selectedSize, setSelectedSize] = useState();

    const [selectedColor, setSelectedColor] = useState();

    const [loading, setLoading] = useState(true);

    const [isViewedIncreasing, setIsViewedIncreasing] = useState(false)

    const nav = useNavigate();

    useEffect(() => {
        fetchProduct(props.slug).then((data) => {
            console.log(data.data)
            setProduct(data.data[0]);
            setPreviewImg(convertImageToFormatGallaryItem(data.data[0]?.image));
            const colorSet = Array.from(new Set(data.data[0].productItems?.map((data: any) => data.color)));
            setColor(colorSet.map((data) => {
                return {
                    value: data,
                    label: data,
                    disabled: false
                }
            }))
            const sizeSet = Array.from(new Set(data.data[0].productItems?.map((data: any) => data.size)));
            setSize(sizeSet.map((data) => {
                return {
                    value: data,
                    label: data,
                    disabled: false
                }
            }))
            if (!isViewedIncreasing)
                increaseViewForProduct(data.data[0].id).then(() => { setIsViewedIncreasing(true) });
        }).finally(() => setLoading(false))
    }, [props])

    const handleColorOnClick = ({ target }: RadioChangeEvent) => {
        console.log(color)
        setSelectedColor(target.value)
        console.log(product)

        const size = Array.from(new Set(product?.productItems.filter((item) => item.color === target.value).map((data) => data.size)));

        console.log(size)

        setSize((prev) => prev?.map((data) => {
            if (!size?.some((item) => item === data?.value))
                return { ...data, disabled: true };
            else
                return { ...data, disabled: false };
        })
        )
    }

    const handleSizeOnClick = ({ target }: RadioChangeEvent) => {
        setSelectedSize(target.value);
        const color = Array.from(new Set(product?.productItems.filter((item) => item.size === target.value).map((data) => data.color)));

        console.log(color)

        setColor((prev) => prev?.map((data) => {
            if (!color?.some((item) => item === data.value))
                return { ...data, disabled: true };
            else
                return { ...data, disabled: false };
        })
        )
    }

    const handleBuyNow = () => {
        const currentUser = LocalStorage.getItem('user');

        if (selectedColor && selectedSize) {
            const productItem = product?.productItems.filter((item) => item.color === selectedColor && item.size === selectedSize)
            if (currentUser) {
                createCart({
                    userID: currentUser.id,
                    itemID: productItem[0]?.id,
                    quantity: quantity,
                }).then((data) => {
                    const newCartItem: ICart = {
                        id: data.data.id,
                        itemID: productItem[0]?.id,
                        quantity: quantity,
                        userID: LocalStorage.getItem('user') ? LocalStorage.getItem('user').id : undefined,
                        product_item: {
                            color: selectedColor,
                            size: selectedSize,
                            product: product,
                        }
                    }
                    if (LocalStorage.getItem('cart') &&
                        !Array(LocalStorage.getItem('cart')).some((data: any) =>
                            JSON.stringify(data[0]) === JSON.stringify(newCartItem))) {
                        LocalStorage.setItem('cart', [...LocalStorage.getItem('cart'), newCartItem]);
                    }
                    else if (!LocalStorage.getItem('cart')){
                        LocalStorage.setItem('cart', [newCartItem])
                    }
                    SuccessAlert('Thêm vào giỏ hàng thành công.');
                    nav('/cart');
                })
            }
            else {
                const newCartItem: ICart = {
                    itemID: productItem[0]?.id,
                    quantity: quantity,
                    userID: LocalStorage.getItem('user') ? LocalStorage.getItem('user').id : undefined,
                    product_item: {
                        color: selectedColor,
                        size: selectedSize,
                        product: product,
                    }
                }
                if (LocalStorage.getItem('cart') &&
                    !Array(LocalStorage.getItem('cart')).some((data: any) =>
                        JSON.stringify(data[0]) === JSON.stringify(newCartItem))) {
                    LocalStorage.setItem('cart', [...LocalStorage.getItem('cart'), newCartItem]);
                }
                else if (!LocalStorage.getItem('cart')){
                    LocalStorage.setItem('cart', [newCartItem])
                }
                SuccessAlert('Thêm vào giỏ hàng thành công.');
                nav('/cart');
            }
        }
        else {
            ErrorAlert("Vui lòng chọn size và màu");
        }
    }

    const handleAddToCart = () => {
        const currentUser = LocalStorage.getItem('user');
        if (selectedColor && selectedSize) {
            const productItem = product?.productItems.filter((item) => item.color === selectedColor && item.size === selectedSize)
            if (currentUser) {
                createCart({
                    userID: currentUser.id,
                    itemID: productItem[0]?.id,
                    quantity: quantity,
                }).then((data) => {
                    const newCartItem: ICart = {
                        id: data.data.id,
                        itemID: productItem[0]?.id,
                        quantity: quantity,
                        userID: LocalStorage.getItem('user') ? LocalStorage.getItem('user').id : undefined,
                        product_item: {
                            color: selectedColor,
                            size: selectedSize,
                            product: product,
                        }
                    }
                    if (LocalStorage.getItem('cart') &&
                        !LocalStorage.getItem('cart').some((value: any) =>
                         value.itemID === newCartItem.itemID)) {
                        LocalStorage.setItem('cart', [...LocalStorage.getItem('cart'), newCartItem]);
                    }
                    else if (!LocalStorage.getItem('cart'))
                        LocalStorage.setItem('cart', [newCartItem])
                    SuccessAlert('Thêm vào giỏ hàng thành công.')
                })
            }
            else {
                const newCartItem: ICart = {
                    itemID: productItem[0]?.id,
                    quantity: quantity,
                    userID: LocalStorage.getItem('user') ? LocalStorage.getItem('user').id : undefined,
                    product_item: {
                        color: selectedColor,
                        size: selectedSize,
                        product: product,
                    }
                }
                if (LocalStorage.getItem('cart') &&
                    !(LocalStorage.getItem('cart')).some((data: any) =>
                        data.itemID === newCartItem.itemID)){
                    LocalStorage.setItem('cart', [...LocalStorage.getItem('cart'), newCartItem]);
                }
                else if (!LocalStorage.getItem('cart'))
                    LocalStorage.setItem('cart', [newCartItem])
                SuccessAlert('Thêm vào giỏ hàng thành công.')
            }
        }
        else {
            ErrorAlert("Vui lòng chọn size và màu");
        }
    }

    return (
        <Spin spinning={loading}>

            <Row style={{ width: '100%' }}>
                <Col span={13} style={{ marginTop: 20 }}>
                    <ImageGallery items={previewImg ? previewImg : images} thumbnailPosition={'left'} showPlayButton={false} showFullscreenButton={false} />
                </Col>
                <Col offset={1} span={10}>
                    <div className="product__info">
                        <h1 className="product__info__title">{product?.name}</h1>
                        <Space>
                            <Typography.Text type='secondary'>Lượt mua: {product?.sold}</Typography.Text>
                            <Typography.Text type='secondary'>Lượt xem: {product?.view}</Typography.Text>
                        </Space>
                        <div className="product__info__item">
                            <span className="product__info__item__price">
                                {formatNumberWithComma(product?.price)}
                                {product?.discount?.discount && product.discount.discount > 0 ? <span className="product-card__price__old">
                                    <del>{formatNumberWithComma(product?.price)}</del>
                                </span> : null}
                            </span>
                        </div>
                        <div className="product__info__item">
                            <div className="product__info__item__title">
                                Màu sắc
                            </div>
                            <div className="product__info__item__list">
                                <Radio.Group
                                    onChange={handleColorOnClick}
                                    options={color}
                                    // value={value4}
                                    optionType="button"
                                    buttonStyle="solid"
                                />
                            </div>
                        </div>
                        <div className="product__info__item">
                            <div className="product__info__item__title">
                                Kích cỡ
                            </div>
                            <div className="product__info__item__list">
                                <Radio.Group
                                    options={size}
                                    onChange={handleSizeOnClick}
                                    // value={value4}
                                    optionType="button"
                                    buttonStyle="solid"
                                />
                            </div>
                        </div>
                        <div className="product__info__item">
                            <div className="product__info__item__title">
                                Số lượng
                            </div>
                            <div>
                                <InputNumber defaultValue={1} onChange={(value) => setQuantity(value)} />
                            </div>
                        </div>
                        <div className="product__info__item">
                            <Button
                                onClick={handleAddToCart}
                            >Thêm vào giỏ</Button>
                            <Button onClick={handleBuyNow}>Mua ngay</Button>
                        </div>
                        <div className={`product-description expand`}>
                            <div className="product-description__title">
                                Chi tiết sản phẩm
                            </div>
                            <div className="product-description__content">{product?.description}</div>
                        </div>
                        <Space style={{ marginTop: 15 }}>
                            <Typography.Text>Thẻ: </Typography.Text>
                            {product?.HaveTag ? product?.HaveTag.map((tag) => <Tag>{tag.tag.name}</Tag>) : null}
                        </Space>
                    </div>
                </Col>
            </Row>
        </Spin>
    )
}

function convertImageToFormatGallaryItem(images: string[]) {
    return images.map((image) => {
        return {
            original: image,
            originalHeight: 600,
            originalWidth: 1300,
            thumbnail: image,
            thumbnailHeight: 120,
            thumbnailWidth: 250,
        }
    })
}

type ProductViewProps = {
    slug: string
}
export default ProductView